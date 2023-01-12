using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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
    public partial class OrderPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public OrderPage()
        {
            InitializeComponent();
            if (txtAddress.Text == "" || txtAddress.Text == null)
            {
                txtAddress.Text = User.user.DIACHI;
            }
            if (txtName.Text == "" || txtName.Text == null)
            {
                txtName.Text = User.user.HOTEN;
            }
            if (txtsdt.Text == "" || txtsdt.Text == null)
            {
                txtsdt.Text = User.user.SDT;
            }
            User.order.SumMoney = User.order.Sumbf + 30000;
            DoneOrder.BindingContext = User.order;
           
        }
        private async void Thanhtoan_Clicked(object sender, EventArgs e)
        {
            User.order.MaUser = User.user.MA;
            User.order.HoTen = txtName.Text;
            User.order.SDT = txtsdt.Text;
            User.order.Address = txtAddress.Text;
            User.order.Message = txtMessage.Text;

            HttpClient http = new HttpClient();
            string jsonLstproducts = JsonConvert.SerializeObject(User.order);
            StringContent httcontent = new StringContent(jsonLstproducts, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;

            kq = await http.PostAsync("http://192.168.1.13/TechieAPI/api/ServiceController/AddOrder", httcontent);

            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
            {
                await DisplayAlert("Thông báo", "Đặt hàng thành công", "OK");

                User.order.LstProduct = new List<Product>();
                User.order = new Order();
            }
            else
                await DisplayAlert("Thông báo", "Them dữ liệu Lỗi", "ok");

        }

        private void home_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }
        [Obsolete]
        private void onl_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            PopupNavigation.PushAsync(new PopupPayment());
        }
        [Obsolete]
        private async void Back_btn_Tapped(object sender, EventArgs e)
        {
            if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Any())
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}