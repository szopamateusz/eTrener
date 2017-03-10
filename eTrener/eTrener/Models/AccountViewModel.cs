using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;

namespace eTrener.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Enter your email.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string  Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
     

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30,ErrorMessage = "{0} must have at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage = "Passwords are not the same.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "{0} must have at least {2} characters", MinimumLength = 6)]
        public string Login { get; set; }
    }
}