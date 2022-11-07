using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.Models
{
    public class Patient
    {
        [Required]
        public int Patient_Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("[A-Za-z ]{1,30}", ErrorMessage = "Give a proper First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("[A-Za-z ]{1,30}", ErrorMessage = "Give a proper last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Hospital Id is Reguired")]
        public int Hospital_id { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 120, ErrorMessage = "Not valid")]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^(\\+91[\\-\\s]?)?[0]?(91)?[789]\\d{9}$", ErrorMessage = "Give a proper Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-z0-9](\\.?[a-z0-9]){5,}@g(oogle)?mail\\.com$", ErrorMessage = "Give a proper Email Id")]
        public string Email { get; set; }

        [Required]
        public int DeletedStatus { get; set; }
    }
}