using FoodApp.Models;
using FoodApp.Services;
using FoodApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly IApiService apiService;

        private ObservableCollection<Item> shoppingItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> ShoppingItems { get { return shoppingItems; }}
        public ShopinglistPage()
        {
            InitializeComponent();
            apiService = DependencyService.Get<IApiService>();
            BindingContext = new ItemViewModel();

            DisplayItems();
        }

        private async void DisplayItems()
        {
            var items = await apiService.GetItems();

            ShoppingItemsView.ItemsSource = shoppingItems;

            foreach (var item in items)
            {
                shoppingItems.Add(item);
            }
        }

        private void GroupPage_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new GroupPage();
        }
        public void LogOutButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

        private async void RemoveItemButton_Clicked(object sender, EventArgs e)
        {
            var item = (ImageButton)sender;
            bool answer = await DisplayAlert("Delete", "Would you like to delete " + item.AutomationId +"?", "Yes", "No");
            if(!answer)
            {

            }
            else 
            { 
                var itemId = item.ClassId;
                await apiService.DeleteItemAsync(itemId);
                App.Current.MainPage = new ShopinglistPage();
            }
        }
        private async void AddItemButton_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Add", "What do you whant to add?");
            if (result == null)
            {

            }
            else
            {
                Item newItem = new Item()
                {
                    Title = result,
                    person = LoginPage.currentUser
                };
                await apiService.PostItemAsync(newItem);
                App.Current.MainPage = new ShopinglistPage();
            }
        }
    }
}