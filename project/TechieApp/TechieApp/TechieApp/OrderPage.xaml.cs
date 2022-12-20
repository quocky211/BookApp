﻿using Newtonsoft.Json;
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
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
           
        }
        private async void Thanhtoan_Clicked(object sender, EventArgs e)
        {
            User.order.MaUser = User.user.MA;
            User.order.Address = txtAddress.Text;
            User.order.Message = txtMessage.Text;

            HttpClient http = new HttpClient();
            string jsonLstproducts = JsonConvert.SerializeObject(User.order);
            StringContent httcontent = new StringContent(jsonLstproducts, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;

            kq = await http.PostAsync("http://192.168.1.26/TechieAPI/api/ServiceController/AddOrder", httcontent);

            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
            {
                await DisplayAlert("Thông báo", "Đặt hàng thành công", "OK");

                User.order.LstProduct = new List<Product>();
            }
            else
                await DisplayAlert("Thông báo", "Them dữ liệu Lỗi", "ok");

        }
    }
}