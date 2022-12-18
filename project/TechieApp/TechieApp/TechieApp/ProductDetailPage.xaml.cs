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
    public partial class ProductDetailPage : ContentPage
    {   
        public ProductDetailPage()
        {
            InitializeComponent();
        }
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            Intro.BindingContext = product;
        }

    }
}