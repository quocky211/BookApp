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
    public partial class TypeProductPage : ContentPage
    {
        public async void ListType()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.13/TechieAPI/api/ServiceController/ListType");
            var dstype = JsonConvert.DeserializeObject<List<Loai>>(kq);
            Lsttypeofproducts.ItemsSource = dstype;
        }
        public TypeProductPage()
        {
            InitializeComponent();
            ListType();
        }

        private void Lsttypeofproducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Loai selectedLoai = (Loai)Lsttypeofproducts.SelectedItem;
            Navigation.PushAsync(new ListProductByTypePage(selectedLoai));
        }
    }
}