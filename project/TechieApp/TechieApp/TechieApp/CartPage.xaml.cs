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
    public partial class CartPage : ContentPage
    {   
        public CartPage()
        {   
            InitializeComponent();
            Lstprocarts.ItemsSource = User.order.LstProduct;
            User.order.SumMoney = 0;
            foreach (Product product in User.order.LstProduct)
            {
                User.order.SumMoney += (product.price * product.SLuong);
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

            User.order.SumMoney = 0;
            foreach (Product product in User.order.LstProduct)
            {
                User.order.SumMoney += (product.price * product.SLuong);
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
                    User.order.SumMoney = User.order.SumMoney - (product.price*product.SLuong);
                    SumMoney.BindingContext = null;
                    SumMoney.BindingContext = User.order;
                    break;
                }
            }
            Lstprocarts.ItemsSource = null;
            Lstprocarts.ItemsSource = User.order.LstProduct;
        }

        private void Lstprocarts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = (Product)Lstprocarts.SelectedItem;
            Navigation.PushAsync(new ProductDetailPage(selectedProduct));
        }

        private void Buy_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderPage());
        }
    }
}