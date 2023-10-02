namespace TMPS_Labs.Domain.Models;

public static class FahrenheitToCelsiusAdapter {
  private static double _transform(double units) {
    return (units - 32D) * 0.5555555555555556D;
  }

  private static void _transformList(List<double> enumerable) {
    for (int i = 0; i < enumerable.Count; i++) {
      enumerable[i] = _transform(enumerable[i]);
    }
  }

  public static void Adapt(WeatherForecast forecast) {
    forecast.TemperatureUnit            = TemperatureUnit.Celsius;
    forecast.CurrentWeather.Temperature = _transform(forecast.CurrentWeather.Temperature);
    _transformList(forecast.Daily.MinTemperature);
    _transformList(forecast.Daily.MaxTemperature);
    _transformList(forecast.Daily.ApparentMinTemperature);
    _transformList(forecast.Daily.ApparentMaxTemperature);
    _transformList(forecast.Hourly.Temperature);
  }
}
