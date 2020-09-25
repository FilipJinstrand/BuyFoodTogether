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
    public partial class ShopinglistPage : ContentPage
    {
        public ShopinglistPage()
        {
            InitializeComponent();
        }

        private void GroupPage_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new GroupPage();
        }
        public void LogOutButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}