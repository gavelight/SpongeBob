using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sale.Include(s => s.Bran).Include(s => s.Prod);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.ID == id);
            if (sale == null)
            {
                return NotFound();
            }
            else
            {
                sale.Bran = await _context.Branch.SingleOrDefaultAsync(m => m.ID == sale.BranchID);
                sale.Prod = await _context.Product.SingleOrDefaultAsync(m => m.ID == sale.ProductID);
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["BranchID"] = new SelectList(_context.Branch, "ID", "City");
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Description");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Amount,BranchID,ProductID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var applicationUserId = _context.Users.Where(u => u.UserName == userName).First().Id;
                sale.ApplicationUserId = applicationUserId;
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BranchID"] = new SelectList(_context.Branch, "ID", "City", sale.BranchID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Description", sale.ProductID);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.ID == id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["BranchID"] = new SelectList(_context.Branch, "ID", "City", sale.BranchID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Description", sale.ProductID);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Amount,BranchID,ProductID")] Sale sale)
        {
            if (id != sale.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["BranchID"] = new SelectList(_context.Branch, "ID", "Name", sale.BranchID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Name", sale.ProductID);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.ID == id);
            if (sale == null)
            {
                return NotFound();
            }
            else
            {
                sale.Bran = await _context.Branch.SingleOrDefaultAsync(m => m.ID == sale.BranchID);
                sale.Prod = await _context.Product.SingleOrDefaultAsync(m => m.ID == sale.ProductID);
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.ID == id);
            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.ID == id);
        }
    }
}
