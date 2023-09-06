namespace TMPS_Labs.Services;

public interface IApiService<T> where T : class {
  Task<T> Get(string identifier);
}
