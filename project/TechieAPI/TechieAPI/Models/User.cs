using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechieAPI.Models
{
    public class User
    {   
        public int MA { get; set; }
        public string HOTEN { get; set; }
        public string TENDN { get; set; }
        public string MATKHAU { get; set; }
        public string DIACHI { get; set; }
        public string EMAIL { get; set; }
        public string SDT { get; set; }
        public List<Product> LstLoveProduct { get; set; }

    }
}