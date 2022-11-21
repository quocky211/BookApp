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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void regisButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home");
        }

        private async void Login_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}