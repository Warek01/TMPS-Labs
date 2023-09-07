using System.Net.Http.Headers;

namespace TMPS_Labs.Services;

public abstract class ApiService<T> : IApiService<T> where T : class {
  protected readonly HttpClient Client = new();

  protected HttpRequestMessage GenerateHttpRequest(string url) {
    HttpRequestMessage request = new(HttpMethod.Get, url);
    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    request.Headers.Add("User-Agent", "Local");

    return request;
  }
  
  public abstract Task<T> Get(string username);
}
