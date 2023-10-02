using TMPS_Labs.Client;

WeatherApp app     = new("Forecast App");
bool       success = await app.Run();
Console.WriteLine($"{app.Title} finished execution {(success ? "successfully" : "with error")}");
