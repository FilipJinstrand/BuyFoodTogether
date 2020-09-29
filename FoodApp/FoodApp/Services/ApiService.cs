using FoodApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class ApiService : IApiService
    {
        private readonly string url = "https://buyfoodapi.azurewebsites.net/api/";

        public async Task<List<Item>> GetItems()
        {
            var data = await Get(url + "items");
            return JsonConvert.DeserializeObject<List<Item>>(data);
        }


        public async Task<List<Person>> GetPersons()
        {
            var data = await Get(url + "persons");
            return JsonConvert.DeserializeObject<List<Person>>(data);
        }


        private async Task<string> Get(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "Someting went wrong";
        }
    }
}
