using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Branch
    {
        public int ID { get; set; }

        [Display(Name = "שם")]
        [Required(ErrorMessage = "שדה שם הינו שדה חובה")]
        public string Name { get; set; }

        [Display(Name = "איזור")]
        [Required(ErrorMessage = "שדה איזור הינו שדה חובה")]
        public string Region { get; set; }

        [Display(Name = "עיר")]
        [Required(ErrorMessage = "שדה עיר הינו שדה חובה")]
        public string City { get; set; }

        [Display(Name = "מספר טלפון")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "שדה מספר טלפון הינו שדה חובה")]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{7})$", ErrorMessage = "מספר הטלפון שהוזן אינו תקין")]
        public string PhoneNumber { get; set; }

        [Display(Name = "תאריך הקמה")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "שדה תאריך הקמה הינו שדה חובה")]
        public DateTime FoundationDate { get; set; }

        [Display(Name = "נגיש לנכים?")]
        public bool IsDisabledAccess { get; set; }

        [Display(Name = "כשר?")]
        public bool IsKosher { get; set; }

        [Display(Name = "האם ניתן לקיים אירועים?")]
        public bool IsEventsAllowed { get; set; }
    }
}
