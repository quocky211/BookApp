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
using TechieApp.Model;
using System.Collections.ObjectModel;

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProductByTypePage : ContentPage
    {
        private int tapCount = 0;
        public static ObservableCollection<Product> ProductLists;

        public ListProductByTypePage()
        {
            InitializeComponent();
        }
        public async void ProductByType(Loai loai)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.13/TechieAPI/api/ServiceController/ListProductByType?loai=" + loai.MA.ToString());
            var dslh = JsonConvert.DeserializeObject<ObservableCollection<Product>>(kq);
            ProductLists = dslh;
            LstproductsByType.ItemsSource = dslh;

            Exchange.Data.MyCoView = LstproductsByType;
            Exchange.Data.Xes = dslh;

        }
        public ListProductByTypePage(Loai loai)
        {
            InitializeComponent();
            ProductByType(loai);
            txttype.Text = loai.NAMETYPE;
        }

        [Obsolete]
        private void LstproductsByType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Product selectedProduct = (Product)LstproductsByType.SelectedItem;
            // Navigation.PushAsync(new ProductDetailPage(selectedProduct));

            var a = e.CurrentSelection.FirstOrDefault() as Product;
            PopupNavigation.PushAsync(new ProductDetailPage(a));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            LstproductsByType.ItemsSource = ProductLists.Where(Product => Product.name.ToLower().Contains(e.NewTextValue));
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
        }
        [Obsolete]
        private async void Filter_btn_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new PageFilter());
        }

        private void Back_btn_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}