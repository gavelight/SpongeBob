using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "שדה אימייל הינו שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת האימייל שהוזנה לא תקינה")]
        [Display(Name = "אימייל")]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה סיסמא הינו שדה חובה")]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }

        [Display(Name = "לזכור אותי?")]
        public bool RememberMe { get; set; }
    }
}
