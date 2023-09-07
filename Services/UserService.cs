using System.Net.Http.Headers;
using System.Text.Json;
using TMPS_Labs.Models;

namespace TMPS_Labs.Services;

public class UserService : CacheApiService<User> {
  private const string Url = "https://api.github.com/users";

  public override async Task<User> Get(string username) {
    User? user = Cache.Find(u => u.Login.ToLower() == username);

    if (user is not null) {
      return user;
    }

    using HttpRequestMessage request = GenerateHttpRequest($"{Url}/{username}");
    HttpResponseMessage      res     = await Client.SendAsync(request);
    Stream                   stream  = await res.Content.ReadAsStreamAsync();
    user = await JsonSerializer.DeserializeAsync<User>(stream);

    if (user is null) {
      throw new Exception("User is null");
    }

    Cache.Add(user);

    return user;
  }
}
