using System.Text.Json.Serialization;

namespace TMPS_Labs.Models;

public class Repository {
  [JsonPropertyName("id")]               public long     Id              { get; set; }
  [JsonPropertyName("name")]             public string   Name            { get; set; }
  [JsonPropertyName("full_name")]        public string   FullName        { get; set; }
  [JsonPropertyName("description")]      public string   Description     { get; set; }
  [JsonPropertyName("html_url")]         public string   HtmlUrl         { get; set; }
  [JsonPropertyName("stargazers_count")] public int      StargazersCount { get; set; }
  [JsonPropertyName("watchers_count")]   public int      WatchersCount   { get; set; }
  [JsonPropertyName("language")]         public string   Language        { get; set; }
  [JsonPropertyName("created_at")]       public DateTime CreatedAt       { get; set; }
  [JsonPropertyName("updated_at")]       public DateTime UpdatedAt       { get; set; }
  [JsonPropertyName("owner")]            public User     Owner           { get; set; }
}
