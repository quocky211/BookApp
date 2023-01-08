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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

        }
        private async void regisButton_Clicked(object sender, EventArgs e)
        {
            if (txtpassword.Text!=txtpassword1.Text)
            {
                await DisplayAlert("Thông báo", "Mật khẩu nhập lại không đúng", "OK");
                return;
            }
            User user =new User {HOTEN = txtfullname.Text,TENDN = txtusername.Text,MATKHAU=txtpassword.Text,DIACHI=txtaddress.Text ,EMAIL=txtemail.Text,SDT=txtsdt.Text};
            HttpClient http = new HttpClient();
            string jsonuser = JsonConvert.SerializeObject(user);
            StringContent httpcontent = new StringContent(jsonuser,Encoding.UTF8,"application/json");
            HttpResponseMessage kq = await http.PostAsync("http://192.168.1.13/TechieAPI/api/ServiceController/ThemUser", httpcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            user=JsonConvert.DeserializeObject<User>(kqtv);
            if (user.MA >0)
            {   
                User.user=user;
                User.order.LstProduct = new List<Product>();
                User.user.LstLoveProduct = new List<Product>();
                await DisplayAlert("Thông báo", "Đăng ký thành công", "OK");
                await Shell.Current.GoToAsync("//Home");

            }
            else
            {
                await DisplayAlert("Thông báo", "Tên đăng nhập đã tồn tại", "OK");
            }
        }

        private async void Login_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}