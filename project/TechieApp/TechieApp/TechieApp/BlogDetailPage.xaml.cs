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
    public partial class BlogDetailPage : ContentPage
    {
        public BlogDetailPage()
        {
            InitializeComponent();
        }
        public BlogDetailPage(Blog blog)
        {
            InitializeComponent();
            BlogDetail.BindingContext=blog;
        }

        private void Back_btn_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}