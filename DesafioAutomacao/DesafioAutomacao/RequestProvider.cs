

using System.Net.Http.Json;
using System.Text.Json;

namespace DesafioAutomacao
{
    public class RequestProvider
    {
         private readonly Lazy<HttpClient> _httpClient =
            new(() =>
            {
                var httpCliente = new HttpClient();
                httpCliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return httpCliente;
            }, LazyThreadSafetyMode.ExecutionAndPublication);
        
        public async Task<TResult?> GetAsync<TResult>(string url)
        {
            var httpClient = _httpClient.Value;
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            //tratamento de erro
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
              return default;
            }
             return await response.Content.ReadFromJsonAsync<TResult>();
        }
        public async Task<TResult?> PutAsync<TResult>(string url, TResult data)
        {
            var httpClient = _httpClient.Value;
            var content = new StringContent(JsonSerializer.Serialize(data));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);

            return await response.Content.ReadFromJsonAsync<TResult>();
        }
    }
}