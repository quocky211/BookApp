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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            if (User.user.MA > 0)
            {
                txtname.Text = User.user.HOTEN;
                txtgmail.Text = User.user.EMAIL;
            }

        }
    }
}