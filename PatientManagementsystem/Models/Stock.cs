using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.Models
{
    public class Stock
    {
       
        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Total Quantity is required")]
        public string Quantity { get; set; }


        [Required(ErrorMessage = " Unit of Measurement is required")]
        public int UOM { get; set; }

        [Required(ErrorMessage = "Batch Number is required")]
        public string BatchNumber { get; set; }

        [Required(ErrorMessage = "Expiry date is required")]
        public DateTime ExpiryDate { get; set; }
    }
}