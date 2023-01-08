using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductBoughtPage : ContentPage
    {
        public async void ProductBought()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.13/TechieAPI/api/ServiceController/ListProductBought?mauser=" + User.user.MA);
            var productls = JsonConvert.DeserializeObject<ObservableCollection<Product>>(kq);
            LstBoughtProduct.ItemsSource = productls;
        }
        public ProductBoughtPage()
        {
            InitializeComponent();
            ProductBought();
        }

        private void Back_btn_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Product selectedProduct = (Product)bt.BindingContext;
            bool chon = false;
            foreach (Product product in User.order.LstProduct)
            {
                if (selectedProduct.maSp == product.maSp)
                {
                    product.SLuong++;
                    chon = true;
                    break;
                }
            }
            if (chon == false)
            {
                selectedProduct.SLuong = 1;
                User.order.LstProduct.Add(selectedProduct);
            }
            DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
        }
        [Obsolete]
        private void LstBoughtProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = e.CurrentSelection.FirstOrDefault() as Product;
            PopupNavigation.PushAsync(new ProductDetailPage(a));
        }
    }
}