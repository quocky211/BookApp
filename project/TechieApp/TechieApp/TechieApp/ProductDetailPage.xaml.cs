using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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
    public partial class ProductDetailPage : Rg.Plugins.Popup.Pages.PopupPage
    {   
        public ProductDetailPage()
        {
            InitializeComponent();
        }
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            Intro.BindingContext = product;
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

        [Obsolete]
        private async void Back_btn_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}