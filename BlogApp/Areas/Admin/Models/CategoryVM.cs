using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Areas.Admin.Models
{
    public class CategoryVM : BaseVM
    {
        [Required(ErrorMessage ="Kategori boş bırakılamaz")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}