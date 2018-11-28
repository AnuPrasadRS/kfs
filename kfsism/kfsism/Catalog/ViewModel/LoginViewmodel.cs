using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Catalog.ViewModel
{
    public class LoginViewmodel
    {

        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string CNFPassword { get; set; }
        public string Role { get; set; }
        public string Code { get; set; }
    }
    public class ForgotPassViewmodel
    {
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string CNFPassword { get; set; }
        public string Code { get; set; }
    }
}