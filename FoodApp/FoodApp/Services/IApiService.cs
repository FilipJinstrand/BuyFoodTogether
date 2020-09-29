using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public interface IApiService
    {
        Task<Item> GetItem();

        Task<Person> GetPerson();
    }
}
