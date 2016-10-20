using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{


    public class Sale
    {
        public int ID { get; set; }

        [ForeignKey("Bran")]
        [Display(Name = "סניף")]
        [Required(ErrorMessage = "שדה סניף הינו שדה חובה")]
        public int BranchID { get; set; }

        [ForeignKey("Prod")]
        [Display(Name = "מוצר")]
        [Required(ErrorMessage = "שדה מוצר הינו שדה חובה")]
        public int ProductID { get; set; }

        [Display(Name = "כמות")]
        [Required(ErrorMessage = "שדה כמות הינו שדה חובה")]
        public int Amount { get; set; }

        public virtual Branch Bran { get; set; }

        public virtual Product Prod { get; set; }
    }
}
