using TmpsLabs.Buildings;
using TmpsLabs.Models;

namespace TmpsLabs.Events;

public class ConstructEvent : BuildingEvent {
  public ConstructEvent(CityRegion region, string name) :
      base(region, EventType.Construct, name) { }

  public override void Execute() {
    var building = BuildingFactory.CreateRandomBuilding();
    building.Name = Name;
    Region.AddBuilding(building);
  }
}
