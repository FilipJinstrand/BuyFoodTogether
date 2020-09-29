using FoodApp.Services;
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
        IApiService apiService;
        public LoginPage()
        {
            InitializeComponent();
            apiService = DependencyService.Get<IApiService>();
        }

        private async void Signin_Clicked(object sender, EventArgs e)
        {
            var users = await apiService.GetPersons();

            foreach (var user in users)
            {
                if (user.Name == entry_Username.Text)
                {
                    App.Current.MainPage = new ShopinglistPage();
                }
                else
                {
                    errorUsername.TextColor = Color.FromHex("#4A4A4A");
                }
            }
        }
    }
}