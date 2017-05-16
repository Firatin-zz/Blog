using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Areas.Admin.Models
{
    public class HakkimdaVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Bilgilerim { get; set; }
        public HttpPostedFileBase PostImage { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}