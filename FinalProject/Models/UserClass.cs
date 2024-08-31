using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class UserClass
    {
        [Required(ErrorMessage = "Enter UserName !")]
        [Display(Name = "UserName")]
        [StringLength(maximumLength: 7, MinimumLength = 3, ErrorMessage = "Length 3 - 7")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Please Enter the Email address !")]
        [Display(Name = "Email Id")]
        public string Uemail { get; set; }

        [Required(ErrorMessage = "Enter the Password !")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Upwd { get; set; }

        [Required(ErrorMessage = "Enter the RePassword !")]
        [Display(Name = "Re-Password")]
        [DataType(DataType.Password)]
        [Compare("Upwd")]
        public string Repwd { get; set; }

        [Required(ErrorMessage = "Enter the Mobile Number !")]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

       // [Required(ErrorMessage = "Enter the Education Qualification !")]
       // [Display(Name = "Education")]
        //public string Education { get; set; }

       // [Required(ErrorMessage = "Enter the Address !")]
      //  [Display(Name = "Address")]
      //  public string Address { get; set; }

        //[Required(ErrorMessage = "Select Profile Image !")]
        [Display(Name = "Profile Image")]
        public string Uimg { get; set; }
       
        public bool isActive { get; set; }
    }
}