using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models.Entity
{
    public class Base
    {
        public int ID { get; set; }

        private DateTime _addDate = DateTime.Now;//bir değişken tanımlayıp şuan ki zamanı atıyoruz.Bunu AddDate'e göndereceğiz;
        public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }//böylece gelen değer ve okunan değer now olacak

        private bool _isDeleted = false;//IsDeleted false varsayılan olsun diye değişken tanımladık
        public bool IsDeleted { get { return _isDeleted; } set { _isDeleted = value; } }//böylece her ekleme false olacak

        public DateTime? DeleteDate { get; set; }

    }
}