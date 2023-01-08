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

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogPage : ContentPage
    {
        public async void ListBlogAPI()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.13/TechieAPI/api/ServiceController/ListBlog");
            var dsblog = JsonConvert.DeserializeObject<ObservableCollection<Blog>>(kq);
            ListBlog.ItemsSource = dsblog;
        }
        public BlogPage()
        {
            InitializeComponent();
            ListBlogAPI();
        }

        private void ListBlog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Blog blog = (Blog)ListBlog.SelectedItem;
            Navigation.PushAsync(new BlogDetailPage(blog));
        }
    }
}