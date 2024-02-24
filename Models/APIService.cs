using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace Stulio.Models
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
           // _httpClient.BaseAddress = new Uri("https://localhost:7220/"); // Replace with your API URL
        }

        public async Task<string> GetTodoItemsAsync()
        {
            Uri uri = new Uri("https://localhost:7220/WeatherForecast");
            var response = await _httpClient.GetAsync(uri); // Replace with your API endpoint
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("{0}", response.Content);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            var content = await response.Content.ReadAsStringAsync();
            return content;
            // response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();
            //return JsonSerializer.Deserialize<List<TodoItem>>(content);
        }
    }
}