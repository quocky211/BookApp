using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechieAPI.Models
{
    public class Order
    {
        public int MaUser { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public List<Product> LstProduct { get; set; }
    }
}