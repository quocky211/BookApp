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
    public partial class ProductDetailPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private int tapCount = 0;
        public ProductDetailPage()
        {
            InitializeComponent();
        }
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            Intro.BindingContext = product;
            btn_feature.BindingContext=product;
            ListRelated(product.loai);
            
        }
        public async void ListRelated(int ma)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.13/TechieAPI/api/ServiceController/ListProductByType?loai=" + ma.ToString());
            var dslh = JsonConvert.DeserializeObject<ObservableCollection<Product>>(kq);
            LstRelated.ItemsSource = dslh;
        }
        [Obsolete]
        private async void Back_btn_Tapped(object sender, EventArgs e)
        {
            if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Any())
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }

        [Obsolete]
        private void LstRelated_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = e.CurrentSelection.FirstOrDefault() as Product;
            PopupNavigation.PushAsync(new ProductDetailPage(a));
        }

        private void ImgAddToWishList_Tapped(object sender, EventArgs e)
        {
            tapCount++;
            var imgSource = (Image)sender;
            if (tapCount % 2 == 0)
            {
                imgSource.Source = "FavouriteRedIcon.png";
            }
            else
            {
                imgSource.Source = "FavouriteBlackIcon.png";
            }

            Image image = (Image)sender;
            Product selectedProduct = (Product)image.BindingContext;
            bool chon = false;
            if (User.user.LstLoveProduct != null)
            {
                foreach (Product product in User.user.LstLoveProduct)
                {
                    if (selectedProduct.maSp == product.maSp)
                    {
                        chon = true;
                        break;
                    }
                }
            }
            if (chon == false)
            {
                User.user.LstLoveProduct.Add(selectedProduct);
                DisplayAlert("Thông báo", "Đã thêm vào  danh sách yêu thích", "OK");
            }
        }
        [Obsolete]
        private void Buy_btn_Clicked_1(object sender, EventArgs e)
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
            PopupNavigation.PushAsync(new CartPage());
        }

        private void addCart_btn_Clicked_1(object sender, EventArgs e)
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
    }
}