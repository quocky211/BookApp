using System;
using System.Collections.Generic;
using System.Text;

namespace TechieApp
{
    public class Order
    {
        public int MaUser { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
        public List<Product> LstProduct { get; set; }
        public int SumMoney { get; set; }
    }
}
