using TmpsLabs.Buildings;
using TmpsLabs.Events;

namespace TmpsLabs.Models;

public static class TownHall {
  private static readonly List<string> _streetNames = new() {
      "Main Street",
      "Elm Street",
      "Maple Avenue",
      "Oak Drive",
      "Cedar Lane",
      "Pine Road",
      "Birch Court",
      "Willow Lane",
      "Spruce Street",
      "Juniper Road",
      "Sycamore Avenue",
      "Cypress Drive"
  };

  private static string _randomStreetName =>
      _streetNames[new Random().Next(_streetNames.Count)];

  public static void Build(CityRegion region) {
    BuildingEvent buildingEvent = new ConstructEvent(region, _randomStreetName);
    buildingEvent.Execute();
  }

  public static void Destruct(CityRegion region, Building building) {
    BuildingEvent buildingEvent = new DeconstructEvent(region, building);
    buildingEvent.Execute();
  }

  public static void Populate(CityRegion region, Building building, int populationCount) {
    BuildingEvent buildingEvent = new PopulateEvent(region, building, populationCount);
    buildingEvent.Execute();
  }
}
