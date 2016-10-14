using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "שדה שם פרטי הינו שדה חובה")]
        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "שדה שם משפחה הינו שדה חובה")]
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "שדה אימייל הינו שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת האימייל שהוזנה לא תקינה")]
        [Display(Name = "אימייל")]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה סיסמא הינו שדה חובה")]
        [StringLength(100, ErrorMessage = "ה{0} חייבת להיות באורך של בין {2} ל {1} תווים", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אישור סיסמא")]
        [Compare("Password", ErrorMessage = "השדות סיסמא ואישור סיסמא אינם תואמים.")]
        public string ConfirmPassword { get; set; }
    }
}
