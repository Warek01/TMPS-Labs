using System.Text.Json.Serialization;

namespace TMPS_Labs.Domain.Models;

public class WeatherForecast {
  public                                       TemperatureUnit TemperatureUnit;
  [JsonPropertyName("current_weather")] public Weather         CurrentWeather { get; set; } = null!;
  [JsonPropertyName("hourly")]          public HourlyForecast  Hourly         { get; set; } = null!;
  [JsonPropertyName("timezone")]        public string          Timezone       { get; set; } = null!;
  [JsonPropertyName("elevation")]       public double          Elevation      { get; set; }
  [JsonPropertyName("daily")]           public DailyForecast   Daily          { get; set; } = null!;

  [JsonPropertyName("timezone_abbreviation")]
  public string TimezoneAbbreviation { get; set; } = null!;

  public class Weather {
    [JsonPropertyName("is_day")]        public int      IsDay         { get; set; }
    [JsonPropertyName("temperature")]   public double   Temperature   { get; set; }
    [JsonPropertyName("time")]          public DateTime Time          { get; set; }
    [JsonPropertyName("weathercode")]   public int      WeatherCode   { get; set; }
    [JsonPropertyName("winddirection")] public int      WindDirection { get; set; }
    [JsonPropertyName("windspeed")]     public double   WindSpeed     { get; set; }
  }

  public class HourlyForecast {
    [JsonPropertyName("time")]           public List<DateTime> Time        { get; set; } = null!;
    [JsonPropertyName("temperature_2m")] public List<double>   Temperature { get; set; } = null!;
    [JsonPropertyName("windspeed_10m")]  public List<double>   WindSpeed   { get; set; } = null!;
    [JsonPropertyName("weathercode")]    public List<int>      WeatherCode { get; set; } = null!;

    [JsonPropertyName("relativehumidity_2m")]
    public List<int> Humidity { get; set; } = null!;
  }

  public class DailyForecast : HourlyForecast {
    [JsonPropertyName("temperature_2m_max")]
    public List<double> MaxTemperature { get; set; } = null!;

    [JsonPropertyName("temperature_2m_min")]
    public List<double> MinTemperature { get; set; } = null!;

    [JsonPropertyName("apparent_temperature_max")]
    public List<double> ApparentMaxTemperature { get; set; } = null!;

    [JsonPropertyName("apparent_temperature_min")]
    public List<double> ApparentMinTemperature { get; set; } = null!;

    [JsonPropertyName("sunrise")] public List<DateTime> Sunrise { get; set; } = null!;
    [JsonPropertyName("sunset")]  public List<DateTime> Sunset  { get; set; } = null!;
  }
}
