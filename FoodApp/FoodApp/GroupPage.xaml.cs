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
        private async void RemovePersonButton_Clicked(object sender, EventArgs e)
        {
            var person = (ImageButton)sender;
            bool answer = await DisplayAlert("Delete", "Would you like to delete "+ person.AutomationId +"?", "Yes", "No");
            if (!answer)
            {

            }
            else
            {
                var personId = person.ClassId;
                await apiService.DeletePersonAsync(personId);
                App.Current.MainPage = new GroupPage();
            }
        }

        private async void AddPersonButton_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Add", "Who do you want to join?");
            Person newPerson = new Person()
            {
                Name = result,
            };
            await apiService.PostPersonAsync(newPerson);
            App.Current.MainPage = new GroupPage();
        }
    }
}