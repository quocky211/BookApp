using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home");
        }

        private async void Register_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login/Register");
        }
    }
}