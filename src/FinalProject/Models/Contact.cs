using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "שדה שם הינו שדה חובה")]
        [Display(Name = "שם")]
        public string Name { get; set; }

        [Required(ErrorMessage = "שדה אימייל הינו שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת האימייל שהוזנה לא תקינה")]
        [Display(Name = "אימייל")]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה נושא הינו שדה חובה")]
        [Display(Name = "נושא")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "שדה הודעה הינו שדה חובה")]
        [Display(Name = "הודעה")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
