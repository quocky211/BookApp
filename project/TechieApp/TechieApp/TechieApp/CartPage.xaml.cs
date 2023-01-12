using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : Rg.Plugins.Popup.Pages.PopupPage
    {   
        public CartPage()
        {   
            InitializeComponent();
            Lstprocarts.ItemsSource = User.order.LstProduct;
            User.order.Sumbf = 0;
            foreach (Product product in User.order.LstProduct)
            {
                User.order.Sumbf += (product.price * product.SLuong);
            }
            SumMoney.BindingContext = User.order;
        }

        private void Update_btn_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Product selectedProduct = (Product)bt.BindingContext;
            foreach (Product product in User.order.LstProduct)
            {
                if (product.maSp == selectedProduct.maSp)
                {   
                    product.SLuong = selectedProduct.SLuong;
                    break;
                }
            }

            User.order.Sumbf = 0;
            foreach (Product product in User.order.LstProduct)
            {
                User.order.Sumbf += (product.price * product.SLuong);
            }
            SumMoney.BindingContext = null;
            SumMoney.BindingContext = User.order;
        }

        private void Delete_btn_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Product selectedProduct = (Product)bt.BindingContext;
            foreach (Product product in User.order.LstProduct)
            {
                if (selectedProduct.maSp == product.maSp)
                {
                    User.order.LstProduct.Remove(selectedProduct);
                    User.order.Sumbf = User.order.Sumbf - (product.price*product.SLuong);
                    SumMoney.BindingContext = null;
                    SumMoney.BindingContext = User.order;
                    break;
                }
            }
            Lstprocarts.ItemsSource = null;
            Lstprocarts.ItemsSource = User.order.LstProduct;
        }
        [Obsolete]
        private void Lstprocarts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = e.CurrentSelection.FirstOrDefault() as Product;
            PopupNavigation.PushAsync(new ProductDetailPage(a));
        }
        [Obsolete]
        private async void Back_btn_Tapped(object sender, EventArgs e)
        {
            if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Any())
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
        [Obsolete]
        private void Buy_btn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new OrderPage());
        }
    }
}