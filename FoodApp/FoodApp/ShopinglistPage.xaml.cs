using FoodApp.Models;
using FoodApp.Services;
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

        private void ShopingItem_Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                
            }
            else if(e.Value == false)
            {
                ShoppingItemsView.BackgroundColor = Color.FromHex("None");
            }
        }

        private void RemoveItemButton_Clicked(object sender, EventArgs e)
        {

        }

        private void AddItemButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}