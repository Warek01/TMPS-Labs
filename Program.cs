using TmpsLabs.Building;
using TmpsLabs.Models;


var region1 = new CityRegion("1");
region1.AddBuilding(BuildingFactory.CreateBuilding(BuildingType.Hospital));
region1.AddBuilding(BuildingFactory.CreateBuilding(BuildingType.Mall));
region1.AddBuilding(BuildingFactory.CreateBuilding(BuildingType.Residential));

foreach (Building b in region1) {
  Console.WriteLine(b.Type);
}

return;
