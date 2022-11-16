using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("[A-Za-z ]{1,30}", ErrorMessage = "Give a proper First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("[A-Za-z ]{1,30}", ErrorMessage = "Give a proper last name")]
        public string LastName { get; set; }

        [Required]
        public int HospitalId { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^(\\+91[\\-\\s]?)?[0]?(91)?[789]\\d{9}$", ErrorMessage = "Give a proper Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }


        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOJ { get; set; }


        [Required]
        public string Designation { get; set; }

        [Required]
        public int isactive { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        public bool Admin { get; set; }
    }
}