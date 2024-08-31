using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage = "Please Enter the Email address !")]
        [Display(Name = "User Details :")]
        public string Uemail { get; set; }

        public bool AccountStatus { get; set; }
        [Required(ErrorMessage = "Please Enter the Password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Upwd { get; set; }
    }
}