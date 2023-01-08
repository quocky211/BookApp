using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoveProductPage : ContentPage
    {
        public LoveProductPage()
        {
            InitializeComponent();
            ListLoveProduct.ItemsSource = User.user.LstLoveProduct;
        }
        private void Back_btn_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        [Obsolete]
        private void ListLoveProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = e.CurrentSelection.FirstOrDefault() as Product;
            PopupNavigation.PushAsync(new ProductDetailPage(a));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Product selectedProduct = (Product)bt.BindingContext;
            foreach (Product product in User.user.LstLoveProduct)
            {
                if (selectedProduct.maSp == product.maSp)
                {
                    User.user.LstLoveProduct.Remove(selectedProduct);
                    break;
                }
            }
            ListLoveProduct.ItemsSource = null;
            ListLoveProduct.ItemsSource = User.user.LstLoveProduct;
        }
    }
}