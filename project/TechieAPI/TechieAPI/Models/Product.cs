using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechieAPI.Models
{
    public class Product
    {
        public int maSp { get; set; }
        public int loai { get; set; }
        public int price { get; set; }
        public string name { get; set; }
        public string hinh { get; set; }
        public string mota { get; set; }
        public int SLuong { get; set; }
    }
}