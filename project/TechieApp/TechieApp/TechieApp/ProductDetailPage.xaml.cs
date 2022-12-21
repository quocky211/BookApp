using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {   
        public ProductDetailPage()
        {
            InitializeComponent();
        }
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            Intro.BindingContext = product;
            Title = product.name;
        }

        private void Buy_btn_Clicked(object sender, EventArgs e)
        {   
            Button bt = (Button)sender;
            Product selectedProduct = (Product)bt.BindingContext;
            bool chon = false;
            foreach(Product product in User.order.LstProduct)
            {
                if (selectedProduct.maSp ==product.maSp)
                {
                    product.SLuong++;
                    chon = true;
                    break;
                }
            }
            if (chon==false)
            {
                selectedProduct.SLuong=1;
                User.order.LstProduct.Add(selectedProduct);
            }
            DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
        }
    }
}