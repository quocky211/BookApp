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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
         async void loginButton_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.6/TechieAPI/api/ServiceController/UserLogin?TENDN=" + txtusername.Text + "&&MATKHAU=" + txtpassword.Text);
            var user = JsonConvert.DeserializeObject<User>(kq);
            if (user.HOTEN != "" && user.HOTEN != null)
            {
                await DisplayAlert("Thông báo", " Chào bạn :" + user.HOTEN, "OK");
                User.user = user;
                await Shell.Current.GoToAsync("//Home");
            }
            else
                await DisplayAlert("Thông báo", " Đăng Nhập Sai :", "OK");

        }

        private async void Register_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login/Register");
        }
    }
}