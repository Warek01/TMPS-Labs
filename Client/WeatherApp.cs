using System.Runtime.InteropServices;
using TMPS_Labs.Domain;
using TMPS_Labs.Domain.Facades;
using TMPS_Labs.Domain.Models;
using TMPS_Labs.Domain.Services;
using TMPS_Labs.Utilities;

namespace TMPS_Labs.Client;

public class WeatherApp {
  public string Title { get; }

  public WeatherApp(string title) {
    Title = title;
  }

  public async Task<bool> Run() {
    try {
      IFs? fs;
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
        fs = new LinuxFs();
      }
      else {
        Console.WriteLine("OS not supported");
        return false;
      }

      IFileService         fileService  = new SimpleFileService(fs);
      Printer              printer      = new();
      SelectForm<Location> locationForm = new();

      locationForm.Vertical();
      locationForm.Title("Select location");
      foreach (Location availableLocation in WeatherForecastFacade.AvailableLocations) {
        locationForm.AddOption(availableLocation, availableLocation.Name);
      }

      Location location = locationForm.Render();

      printer.Clear();
      TemperatureUnit temperatureUnit = new SelectForm<TemperatureUnit>()
                                        .Title("Select unit")
                                        .AddOption(TemperatureUnit.Celsius,    "Celsius")
                                        .AddOption(TemperatureUnit.Fahrenheit, "Fahrenheit")
                                        .Render();

      printer
        .Clear()
        .Text("Fetching ...", ConsoleColor.Blue)
        .NewLine();

      WeatherForecastFacade forecastFacade = new(location, temperatureUnit);
      WeatherForecast?      forecast       = await forecastFacade.Request();

      if (forecast is null) {
        Console.WriteLine("Error loading the forecast");
        return false;
      }

      if (forecast.TemperatureUnit == TemperatureUnit.Fahrenheit) {
        FahrenheitToCelsiusAdapter.Adapt(forecast);
      }

      WeatherForecast fancyForecast = new FancyToStringWeatherForecast(forecast);
      fileService.SaveToFile("Forecast.txt", fancyForecast.ToString()!);

      return true;
    }
    catch (Exception exception) {
      Console.WriteLine(exception);
      return false;
    }
  }
}
