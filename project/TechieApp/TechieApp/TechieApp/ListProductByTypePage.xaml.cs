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
    public partial class ListProductByTypePage : ContentPage
    {
        private int tapCount = 0;
        public static List<Product> ProductLists;

        public ListProductByTypePage()
        {
            InitializeComponent();
        }
        public async void ProductByType(Loai loai)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
              ("http://192.168.1.26/TechieAPI/api/ServiceController/ListProductByType?loai=" + loai.MA.ToString());
            var dslh = JsonConvert.DeserializeObject<List<Product>>(kq);
            ProductLists = dslh;
            LstproductsByType.ItemsSource = dslh;
        }
        public ListProductByTypePage(Loai loai)
        {
            InitializeComponent();
            ProductByType(loai);
            Title = loai.NAMETYPE;
        }

        private void LstproductsByType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = (Product)LstproductsByType.SelectedItem;
            Navigation.PushAsync(new ProductDetailPage(selectedProduct));
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
    }
}