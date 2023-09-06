namespace TMPS_Labs.Services;

public abstract class CacheApiService<T> : ApiService<T> where T : class {
  protected List<T> Cache = new();
}
