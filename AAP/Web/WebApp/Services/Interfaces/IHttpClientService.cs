namespace WebApp.Services.Interfaces;

public interface IHttpClientService
{
    Task<T> GetAsync<T>(string url);
    Task<T> PostAsync<T>(string url, object data);
    Task<T> PutAsync<T>(string url, object data);
    Task<T> DeleteAsync<T>(string uri);
}
