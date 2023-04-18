using Cryptocurrency.BLL.Interfaces;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Cryptocurrency.BLL.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
        }

        public async Task<T> Delete<T>(string path)
        {
            var response = await _httpClient.DeleteAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(json)?["error"]?.ToString());
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Get<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(json)?["error"]?.ToString());
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<string> Get(string path)
        {
            var response = await _httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(json)?["error"]?.ToString());
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<T> Post<T>(string path, object content)
        {
            var httpContext = ConvertToHttpContent(content);

            using var response = await _httpClient.PostAsync(path, httpContext);

            if (!response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(json)?["error"]?.ToString());
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task Put(string path, object content)
        {
            var httpContent = ConvertToHttpContent(content);

            var response = await _httpClient.PutAsync(path, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(json)?["error"]?.ToString());
            }
        }

        private StringContent ConvertToHttpContent(object content)
        {
            return new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
        }
    }
}
