using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private int tapCount = 0;
        public static List<Book> BookLists;
        public void AddSlideImage()
        {
            List<SlideImage> slideImages = new List<SlideImage>();
            slideImages.Add(new SlideImage { SlideImg = "SlideImages_1.jpg" });
            slideImages.Add(new SlideImage { SlideImg = "SlideImages_2.webp" });
            slideImages.Add(new SlideImage { SlideImg = "SlideImages_3.jpg" });
            slideImages.Add(new SlideImage { SlideImg = "SlideImages_4.jpg" });
            slideImages.Add(new SlideImage { SlideImg = "SlideImages_5.png" });
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                banner.Position = (banner.Position + 1) % slideImages.Count;
                return true;
            }));
            banner.ItemsSource = slideImages;
        }
        public async void LayDSBookAPI()
        {
            HttpClient http= new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.26/BookAPI/api/book/LayDsBook");
            var dsbook = JsonConvert.DeserializeObject<List<Book>>(kq);
            BookLists = dsbook;
            Lstbooks.ItemsSource = dsbook;
        }
        public HomePage()
        {
            InitializeComponent();
            AddSlideImage();
            LayDSBookAPI();
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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Lstbooks.ItemsSource = BookLists.Where(Book => Book.TenSach.ToLower().Contains(e.NewTextValue));
        }

        private void Lstbooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            Book selectedBook=(Book)Lstbooks.SelectedItem;
            Navigation.PushAsync(new BookDetailPage(selectedBook));
        }
    }
}