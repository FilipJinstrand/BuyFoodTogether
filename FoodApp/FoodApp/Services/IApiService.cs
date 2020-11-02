using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public interface IApiService
    {
        Task<List<Item>> GetItems();
        Task<bool> PostItemAsync(Item item);
        Task<bool> DeleteItemAsync(String itemId);
        Task<List<Person>> GetPersons();
    }
}
