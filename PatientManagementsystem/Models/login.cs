using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementsystem.Models
{
    public class login
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
       
        public string Password { get; set; }

        [Display(Name = "Hospital Name")]

        public int HospitalID { get; set; }
        public SelectList HospitalName{ get; set; }
       
        [Display(Name = "Hospital Name")]
        public string H_Name { get; set; }

    }
}