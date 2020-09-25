using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Signin_Clicked(object sender, EventArgs e)
        {
            var user = entry_Username.Text;

            if (user == "hej")
            {
                //byt ut MainPage mot shoping lista
                App.Current.MainPage = new ShopinglistPage();
            }
            else
            {
                errorUsername.TextColor = Color.FromHex("#4A4A4A");
            }
        }
    }
}