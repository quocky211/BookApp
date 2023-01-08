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
    public partial class UpdateUserPage : ContentPage
    {
        public async void SumMoney()
        {
            int Money = 0;
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.13/TechieAPI/api/ServiceController/SumMoney?mauser=" + User.user.MA);
            var productls = JsonConvert.DeserializeObject<ObservableCollection<Product>>(kq);
            
            foreach (Product product in productls)
            {
                Money += product.price * product.SLuong;
            }
            if (Money > 0)
            {
                int tien =(int) Money / 1000000;
                int du = (Money % 1000000)/1000;
                txtSumMoney.Text = tien.ToString() + "." + du.ToString() + ".000đ";
                if (tien <5)
                {
                    thanhvien.BackgroundColor=Color.FromRgb(185, 119, 61);
                    txtthanhvien.Text = "Thành viên Đồng";
                }
                else if (tien>=5 && tien <10)
                {
                    thanhvien.BackgroundColor = Color.FromRgb(126, 126, 126);
                    txtthanhvien.Text = "Thành viên Bạc";
                }
                else if (tien >=10 && tien <20)
                {
                    thanhvien.BackgroundColor = Color.FromRgb(239, 226, 154);
                    txtthanhvien.Text = "Thành viên Vàng";
                }
                else
                {
                    thanhvien.BackgroundColor = Color.FromRgb(87, 87, 87);
                    txtthanhvien.Text = "Thành viên Kim Cương";
                }
            }
            else
            {
                txtSumMoney.Text = "0đ";
                thanhvien.BackgroundColor = Color.FromRgb(185, 119, 61);
                txtthanhvien.Text = "Thành viên Đồng";
            }
        }
        public UpdateUserPage()
        {
            InitializeComponent();
            txthoten.Text = User.user.HOTEN;
            txtdiachi.Text = User.user.DIACHI;
            txtsdt.Text = User.user.SDT;
            txtemail.Text = User.user.EMAIL;
            txtdangnhap.Text = User.user.TENDN;
            SumMoney();
        }
        private void Back_btn_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}