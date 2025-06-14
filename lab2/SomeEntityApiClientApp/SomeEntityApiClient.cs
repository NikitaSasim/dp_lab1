using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace SomeEntityApiClientApp
{
    //Facade for SomeEntity API
    public class SomeEntityApiClient
    {
        private readonly HttpClient _httpClient;

        public SomeEntityApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        // Create
        public async Task<SomeEntity?> CreateAsync(SomeEntity entity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/SomeEntity", entity);
            return await response.Content.ReadFromJsonAsync<SomeEntity>();
        }

        // GetOne
        public async Task<SomeEntity?> GetOneAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<SomeEntity>($"api/SomeEntity/{id}");
        }

        // GetMany
        public async Task<List<SomeEntity>> GetManyAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<SomeEntity>>("api/SomeEntity") ?? new List<SomeEntity>();
        }

        // Update
        public async Task<bool> UpdateAsync(int id, SomeEntity entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/SomeEntity/{id}", entity);
            return response.IsSuccessStatusCode;
        }

        // Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/SomeEntity/{id}");
            return response.IsSuccessStatusCode;
        }

        // GetByFilter
        public async Task<List<SomeEntity>> GetByFilterAsync(SomeEntityFilterBuilder filterBuilder)
        {
            string query = filterBuilder.BuildQuery();
            var url = $"api/SomeEntity/filter{query}";
            var result = await _httpClient.GetFromJsonAsync<List<SomeEntity>>(url);
            return result ?? new List<SomeEntity>();
        }

        // Set the image URL for an entity
        public async Task<bool> SetImageAsync(int id, string imageUrl)
        {
            var content = new StringContent($"\"{imageUrl}\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/SomeImageEntity/image/{id}", content);
            return response.IsSuccessStatusCode;
        }

        // Get the image URL for an entity
        public async Task<string?> GetImageAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/SomeImageEntity/image/{id}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync()
                : null;
        }

        // Get extended image entities with optional filters
        public async Task<List<SomeImageEntity>> GetImageEntitiesByFilterAsync(string? status = null, string? name = null)
        {
            var query = new List<string>();
            if (!string.IsNullOrWhiteSpace(status)) query.Add($"status={Uri.EscapeDataString(status)}");
            if (!string.IsNullOrWhiteSpace(name)) query.Add($"name={Uri.EscapeDataString(name)}");

            var url = "api/SomeImageEntity/filter";
            if (query.Count > 0) url += "?" + string.Join("&", query);

            var result = await _httpClient.GetFromJsonAsync<List<SomeImageEntity>>(url);
            return result ?? new List<SomeImageEntity>();
        }

    }
}