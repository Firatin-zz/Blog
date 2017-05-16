using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models.Entity
{
    public class AdminUser:Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [StringLength(30,ErrorMessage ="30 Karakter sınrlaması")]
        public string EMail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}