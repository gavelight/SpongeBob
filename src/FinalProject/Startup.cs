using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace FinalProject
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Creates the admin user and assigns it with the "admin" role
            CreateAdmin(app);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void CreateAdmin(IApplicationBuilder app)
        {
            // Get the db context of the Application
            var context = app.ApplicationServices.GetService<ApplicationDbContext>();

            // Get the user manager
            var userManager = app.ApplicationServices.GetService<UserManager<ApplicationUser>>();

            // Get the role manager
            var roleManager = app.ApplicationServices.GetService<RoleManager<IdentityRole>>();

            // If admin was not already created
            if (!context.Users.Any(t=>t.UserName == "admin@project.com"))
            {
                // Define user
               var user = new ApplicationUser
                {
                    UserName = "admin@project.com",
                    Email = "admin@project.com",
                    FirstName = "מנהל"
                };

                // Create the admin user
                var result = userManager.CreateAsync(user, "Admin1234!").Result;

                // If admin user was created successfully
                if(result.Succeeded)
                {
                    // Define role
                    var role = new IdentityRole("Admin");

                    // Add the admin role
                    var roleResult = roleManager.CreateAsync(role);

                    // Wait for the admin role to be created
                    while (!roleResult.IsCompleted)
                    {

                    }

                    // Assign the admin role to the admin user
                    var assignResult = userManager.AddToRoleAsync(user, "Admin");
                    
                    // Wait for the admin role to be assigned to the admin user
                    while (!assignResult.IsCompleted)
                    {

                    }

                    // Adds admin claim for first name
                    userManager.AddClaimAsync(user, new Claim(ClaimTypes.GivenName, user.FirstName));
                }
            }
        }
    }
}
