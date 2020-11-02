using FoodApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class ApiService : IApiService
    {
        private readonly string url = "https://buyfoodapi.azurewebsites.net/api/";
        private HttpClient client;
        public ApiService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://buyfoodapi.azurewebsites.net/api/");
        }
        public async Task<List<Item>> GetItems()
        {
            var data = await Get(url + "items");
            return JsonConvert.DeserializeObject<List<Item>>(data);
        }
        public async Task<bool> PostItemAsync(Item item)
        {
            var serializedObject = JsonConvert.SerializeObject(item);
            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            HttpResponseMessage response =  await client.PostAsync("items", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteItemAsync(String itemId)
        {
            string id = itemId;
            var uri = new Uri(string.Format(url + "items/" + id));
            HttpResponseMessage response = await client.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Person>> GetPersons()
        {
            var data = await Get(url + "persons");
            return JsonConvert.DeserializeObject<List<Person>>(data);
        }       
        private async Task<string> Get(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "Someting went wrong";
        }
    }
}
