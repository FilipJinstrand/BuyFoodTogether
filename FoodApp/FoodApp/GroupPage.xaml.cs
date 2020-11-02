using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Models;
using FoodApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        private readonly IApiService apiService;
        private List<Person> personsList = new List<Person>();
        public List<Person> PersonsList { get { return personsList; } }
        public GroupPage()
        {
            InitializeComponent();
            apiService = DependencyService.Get<IApiService>();
            DisplayPersons();
        }
        private async void DisplayPersons()
        {
            var persons = await apiService.GetPersons();
            foreach(var person in persons)
            {
                personsList.Add(person);
            }
            GroupCollectionView.ItemsSource = personsList;
        }
        private void ShopinglistPage_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ShopinglistPage();
        }

        public void LogOutButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

        private async void AddPersonButton_Clicked(object sender, EventArgs e)
        {          
                
        }
    }
}