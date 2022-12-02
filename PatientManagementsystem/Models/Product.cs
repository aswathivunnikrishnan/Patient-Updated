using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.Models
{
    public class Product
    {
      
        public int ProductId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("[A-Za-z ]{1,30}", ErrorMessage = "Give a proper First name")]
        public string ProductName { get; set; }


        
        public int Hospital_id { get; set; }


        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Batch Number is required")]
        public string BatchNumber { get; set; }

        [Required(ErrorMessage = "Min Quantity")]
        public int MinQuantity { get; set; }

        [Required]
        public string Reorder { get; set; }

        [Required(ErrorMessage = " Unit of Measurement is required")]
        public int UOM { get; set; }


        [Required(ErrorMessage = "Total Quantity is required")]
        public string Quantity { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpiryDate { get; set; }


    }
}