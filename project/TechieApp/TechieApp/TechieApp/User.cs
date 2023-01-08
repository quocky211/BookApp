using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TechieApp
{
    public class User
    {
        public int MA { get; set; }
        public string HOTEN { get; set; }
        public string TENDN { get; set; }
        public string MATKHAU { get; set; }
        public string EMAIL { get; set; }
        public string DIACHI { get; set; }
        public string SDT { get; set; }

        public static User user;

        public static Order order;
        public List<Product> LstLoveProduct { get; set; }

    }
}
