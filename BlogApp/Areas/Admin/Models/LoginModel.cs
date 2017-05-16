using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="mail adres girin")]
        [EmailAddress(ErrorMessage ="mail uygun değil")]
        public string Email { get; set; }
        [Required(ErrorMessage ="şifre girin")]
        public string Password { get; set; }
    }
}