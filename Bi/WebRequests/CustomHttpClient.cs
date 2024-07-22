using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Client.WebRequests
{
    public class CustomHttpClient : ICustomHttpClient
    {

        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomHttpClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        private void AddJwtToken()
        {
            var token = _httpContextAccessor.HttpContext.Request.Cookies["jwtToken"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            AddJwtToken();
            return await _httpClient.DeleteAsync(requestUri);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            AddJwtToken();
            return await _httpClient.GetAsync(requestUri);
        }

        public async Task<T> GetFromJsonAsync<T>(string requestUri)
        {
            AddJwtToken();
            return await _httpClient.GetFromJsonAsync<T>(requestUri);
        }

        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T obj)
        {
            AddJwtToken();
            var content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string requestUri, T obj)
        {
            AddJwtToken();
            var content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync(requestUri, content);
        }
    }
}
