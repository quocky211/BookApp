using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        private void Update_btn_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Product selectedProduct = (Product)bt.BindingContext;
            foreach (Product product in User.order.LstProduct)
            {
                if (selectedProduct.maSp == product.maSp)
                {
                    product.SLuong = selectedProduct.SLuong;
                    break;
                }
            }
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
                    break;
                }
            }
            Lstprocarts.ItemsSource = null;
            Lstprocarts.ItemsSource = User.order.LstProduct;
        }

        private void Lstprocarts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Buy_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderPage());
        }
    }
}