namespace TMPS_Labs.Services;

public abstract class ApiService<T> : IApiService<T> where T : class {
  protected readonly HttpClient Client = new();
  public abstract Task<T> Get(string identifier);
}
