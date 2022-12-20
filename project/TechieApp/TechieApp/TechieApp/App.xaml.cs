using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechieApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            User.user = new User();
            User.order = new Order();
            User.order.LstProduct = new System.Collections.Generic.List<Product>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
