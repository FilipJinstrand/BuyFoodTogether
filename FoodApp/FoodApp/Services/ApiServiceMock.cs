using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class ApiServiceMock : IApiService
    {
        public async Task<Item> GetItem()
        {
            await Task.Run(() => { });


            return new Item
            {
                Id = "Hej",
                Title = "Köpt Bröd",
                Person = "Karl"
            };
        }

        public async Task<Person> GetPerson()
        {
            await Task.Run(() => { });

            return new Person
            {
                Id = "akjshd",
                Name = "Karl"
            };
        }
    }
}
