using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ORM.Entity
{
    public class Hakkimda
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Bilgilerim { get; set; }
        public string ImagePath { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}