using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("[A-Za-z ]{1,30}", ErrorMessage = "Give a proper First name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }


        [Required(ErrorMessage = "Min Quantity")]
        public int MinQuantity { get; set; }

        [Required]
        public string Reorder { get; set; }

        [Required]
        public int UOM { get; set; }


    }
}