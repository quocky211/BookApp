using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using TechieApp.Model;
using Xamarin.CommunityToolkit.Converters;
using System.Drawing;

namespace TechieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFilter : Rg.Plugins.Popup.Pages.PopupPage
    {
        Filter FX = Exchange.Data.MyFilter;
        public PageFilter()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void Close_btn_Tapped(object sender, EventArgs e)
        {
            if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Any())
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
        private void RangeSlider_ValueChanged(object sender, EventArgs e)
        {
            max.Text = "5.000.000đ";

            if (RangeSlider.LowerValue == 0)
            {
                min.Text = "0đ  –";
            }
            if (RangeSlider.LowerValue < 1000000)
            {
                double du = 0;
                du = RangeSlider.LowerValue / 1000;
                min.Text =  du.ToString() + ".000đ -";
            }
            if (RangeSlider.LowerValue == 1000000)
            {
                min.Text ="1.000.000đ -";
            }
            if (RangeSlider.LowerValue > 1000000)
            {
                int mount = 0;
                double du = 0;
                mount=(int) RangeSlider.LowerValue / 1000000;
                du= (RangeSlider.LowerValue % 1000000)/1000;
                min.Text = mount.ToString() + "." + du.ToString() + ".000đ -";
            }
            if (RangeSlider.LowerValue == RangeSlider.UpperValue)
            {
                int mount = 0;
                mount = (int)RangeSlider.LowerValue / 1000000;
                max.Text = mount.ToString() + ".000.000đ";
                min.Text = "";
                if (RangeSlider.LowerValue == 0)
                {
                    max.Text = "0đ";
                }
            }
            if (RangeSlider.UpperValue< 5000000)
            {
                int mount = 0;
                mount = (int)RangeSlider.UpperValue / 1000000;
                max.Text = mount.ToString() + ".000.000đ";
            }
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            IEnumerable<Product> xes = Exchange.Data.Xes;
            xes = xes.Where(p => p.price <= RangeSlider.UpperValue);
            xes = xes.Where(p => p.price >= RangeSlider.LowerValue);

            Exchange.Data.MyCoView.ItemsSource = xes;

        }
    }
}