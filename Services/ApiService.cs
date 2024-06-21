using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetByIdAsync<T>(string uri, int id)
        {
            var response = await _httpClient.GetAsync($"{uri}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<bool> PutByIdAsync<T>(string uri, int id, T item)
        {
            var response = await _httpClient.PutAsJsonAsync($"{uri}/{id}", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<T>> GetAllAsync<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<T>>();
        }

        public async Task<bool> PostAsync<T>(string uri, T item)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string uri, int id)
        {
            var response = await _httpClient.DeleteAsync($"{uri}/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}

