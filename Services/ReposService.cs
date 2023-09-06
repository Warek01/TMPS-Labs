using System.Net.Http.Headers;
using System.Text.Json;
using TMPS_Labs.Models;

namespace TMPS_Labs.Services;

public class ReposService : ApiService<IEnumerable<Repository>> {
  public override async Task<IEnumerable<Repository>> Get(string username) {
    using HttpRequestMessage request = new(HttpMethod.Get, $"https://api.github.com/users/{username}/repos");
    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    request.Headers.Add("User-Agent", "Local");

    HttpResponseMessage      res    = await Client.SendAsync(request);
    Stream                   stream = await res.Content.ReadAsStreamAsync();
    IEnumerable<Repository>? repos  = await JsonSerializer.DeserializeAsync<IEnumerable<Repository>>(stream);

    if (repos is null) {
      throw new Exception("Repos are null");
    }

    return repos;
  }
}
