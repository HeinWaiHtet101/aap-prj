
using System.Text.Json;

namespace WebApp.Services.Repositories;

public class HttpClientService
    : IHttpClientService
{
    private readonly HttpClient http;
    private readonly JsonSerializerOptions option;
    public HttpClientService(HttpClient http)
    {
        this.http = http;
        this.option = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }
    public async Task<T> PostAsync<T>(string url, object data)
    {
        var response = await http.PostAsJsonAsync(url, data);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        if (content is null)
        {

        }
        return JsonSerializer.Deserialize<T>(content, option);
    }

    public async Task<T> GetAsync<T>(string url)
    {
        var response = await http.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        if(content is null)
        {

        }
        return JsonSerializer.Deserialize<T>(content, option);
    }

    public async Task<T> PutAsync<T>(string url, object data)
    {
        var response = await http.PutAsJsonAsync(url, data);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        if (content is null)
        {

        }
        return JsonSerializer.Deserialize<T>(content, option);
    }

    public async Task<T> DeleteAsync<T>(string uri)
    {
        var response = await http.DeleteAsync(uri);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        if (content is null)
        {

        }
        return JsonSerializer.Deserialize<T>(content, option);
    }


}
