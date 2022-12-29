using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;


namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPayment : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupPayment()
        {
            InitializeComponent();
        }
        [Obsolete]
        private void Close_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();

        }
    }
}