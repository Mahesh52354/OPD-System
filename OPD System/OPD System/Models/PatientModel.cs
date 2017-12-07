using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPD_System.Models
{
    public class PatientRegistration
    {
        public int hid { get; set; }
        public int patientid { get; set; }

        [Required(ErrorMessage ="Patient Name is Required.")]
        [Display(Name = "Patient Name")]
        public string patientname { get; set; }

        [Display(Name = "Birth Date")]
        public string dob { get; set; }

        [Display(Name = "Age")]
        public string age { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Marital Status")]
        public string maritalstatus { get; set; }

        [MaxLength(10,ErrorMessage ="Mobile Number Must be 10 Digit.")]
        [MinLength(10, ErrorMessage = "Mobile Number Must be 10 Digit.")]
        [RegularExpression("^[0-9]$",ErrorMessage ="Mobile Number Must Be Digit.")]
        [Display(Name = "Mobile No.")]
        public string mobile { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email")]
        [Display(Name = "Email Id")]
        public string email { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name ="City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        public string profileimage { get; set; }
        public string CMD { get; set; }

    }

    public class PatientTreatment
    {
    }

    public class PatientHistory
    {
    }
}