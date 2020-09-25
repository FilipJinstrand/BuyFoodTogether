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
    public partial class GroupPage : ContentPage
    {
        public GroupPage()
        {
            InitializeComponent();
        }

        private void ShopinglistPage_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ShopinglistPage();
        }

        public void LogOutButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}