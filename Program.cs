using TmpsLabs.Buildings;
using TmpsLabs.Models;
using EventType = TmpsLabs.Events.BuildingEvent.EventType;

var rand    = new Random();
var region1 = new CityRegion("1");

region1.Subscribe((building, type) => {
  switch (type) {
    case EventType.Construct:
      Console.WriteLine($"Constructed {building.Type} on {building.Name}");
      TownHall.Populate(region1, building, rand.Next(101));
      break;
    case EventType.Deconstruct:
      Console.WriteLine($"Destroyed {building.Type} on {building.Name}");
      break;
    case EventType.Populate:
      Console.WriteLine($"Populated {building.Type} on {building.Name} with {building.Population} people");
      break;
  }
});

TownHall.Build(region1);
TownHall.Build(region1);

foreach (Building b in region1) {
  Console.WriteLine(b.Type);
}
