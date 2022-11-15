using eCinema.Model.Extensions;
using Flurl.Http;
using Flurl;

namespace eCinema.WinUI;

public class APIService
{
    private readonly string _resource;
    private readonly string _endpoint = "https://localhost:7122/api/";

    public APIService(string resource)
    {
        _resource = resource;
    }

    public static string Username;
    public static string Password;
    
    public async Task<T> Get<T>(object? search = null)
    {
        var query = "";
        if (search is not null)
        {
            query = await search.ToQueryString();
        }

        return await $"{_endpoint}{_resource}?{query}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
    }

    public async Task<T> GetById<T>(Guid id)
    {
        return await $"{_endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
    }
    
    public async Task<T> Post<T>(object request)
    {
        return await $"{_endpoint}{_resource}".WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
    }

    public async Task<T> Put<T>(Guid id, object request)
    {
        return await $"{_endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
    }
    
    public async Task<T> Delete<T>(Guid id)
    {
        return await $"{_endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(id).ReceiveJson<T>();
    }
}