using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "שם")]
        [Required(ErrorMessage = "שדה שם הינו שדה חובה")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "שם מוצר צריך להכיל בין 4 ל20 תווים")]
        public string Name { get; set; }

        [Display(Name = "מחיר")]
        [Required(ErrorMessage = "שדה מחיר הינו שדה חובה")]
        public float Price { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "תיאור")] 
        [Required(ErrorMessage = "שדה תיאור הינו שדה חובה")]
        public string Description { get; set; }

        [Display(Name = "צמחוני?")]
        public bool IsVegeterian { get; set; }

        [Display(Name = "טבעוני?")]
        public bool IsVegan { get; set; }

        [Display(Name = "כשר?")]
        public bool IsKosher { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

    }
}
