namespace TMPS_Labs.Domain.Models;

public class FancyToStringWeatherForecast : WeatherForecast {
  public FancyToStringWeatherForecast(WeatherForecast forecast) {
    CurrentWeather       = forecast.CurrentWeather;
    Hourly               = forecast.Hourly;
    Timezone             = forecast.Timezone;
    Elevation            = forecast.Elevation;
    TimezoneAbbreviation = forecast.TimezoneAbbreviation;
    Daily                = forecast.Daily;
  }

  public override string ToString() {
    return $"""
            {CurrentWeather.Time} {(CurrentWeather.IsDay == 1 ? "Day" : "Night")} {Timezone} ({TimezoneAbbreviation}) Elevation: {Elevation}m
            Current temperature: {CurrentWeather.Temperature:N1} °C
            
            Wind speed {CurrentWeather.WindSpeed} km/h at direction {CurrentWeather.WindDirection}°
            
            Today's max is {Daily.MaxTemperature[0]:N1}°C (apparent as {Daily.ApparentMaxTemperature[0]:N1}°C) and min of {Daily.MinTemperature[0]:N1}°C (apparent as {Daily.ApparentMinTemperature[0]:N1}°C)
            
            Sunrise time: {Daily.Sunrise[0]:HH:mm:ss}
            Sunset time: {Daily.Sunset[0]:HH:mm:ss}
            """;
  }
}
