using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
       
        public UserPage()
        {
            InitializeComponent();

        }

        private async void boughtproduct_Tapped(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ProductBoughtPage());
        }

        private async void updateUser_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateUserPage());
        }

        private async void loveproduct_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoveProductPage());
        }

        private async void logout_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }

        private async void voucher_Tapped(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://meober.vn/");
        }

        private async void about_Tapped(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://meober.vn/pages/about-us");
        }

        private async void help_Tapped(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://meober.vn/");
        }
    }
}