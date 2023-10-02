using System.Text.Json;
using TMPS_Labs.Domain.Models;

namespace TMPS_Labs.Domain.Facades;

public class WeatherForecastFacade {
  private readonly Location        _location;
  private readonly TemperatureUnit _temperatureUnit;

  public static readonly List<Location> AvailableLocations = new() {
    new Location("Chisinau",  47.0056, 28.8575),
    new Location("Bucharest", 44.4323, 26.1063),
    new Location("Rome",      41.8919, 12.5113),
    new Location("Moscow",    55.7522, 37.6156),
    new Location("Budapest",  47.4984, 19.0404),
  };

  public WeatherForecastFacade(Location location, TemperatureUnit temperatureUnit) {
    _temperatureUnit = temperatureUnit;
    _location        = location;
  }

  public async Task<WeatherForecast?> Request() {
    using HttpClient         client         = new();
    using HttpRequestMessage requestMessage = new();
    requestMessage.RequestUri = _generateUri();
    requestMessage.Headers.Add("Accept",     "application/json");
    requestMessage.Headers.Add("User-Agent", "dotnet-runtime");

    using HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
    await using Stream responseStream = await responseMessage.Content.ReadAsStreamAsync();
    WeatherForecast? forecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(responseStream);
    
    if (forecast is not null) {
      forecast.TemperatureUnit = _temperatureUnit;
    }

    return forecast;
  }

  private Uri _generateUri() {
    string temperatureUnit = _temperatureUnit switch {
      TemperatureUnit.Fahrenheit   => "fahrenheit",
      TemperatureUnit.Celsius or _ => "celsius"
    };

    return new Uri(
      $"https://api.open-meteo.com/v1/forecast?latitude={_location.Latitude}&longitude={_location.Longitude}&temperature_unit={temperatureUnit}&hourly=temperature_2m,relativehumidity_2m,weathercode&daily=weathercode,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset&current_weather=true&timezone=Europe%2FBerlin&forecast_days=1"
    );
  }
}
