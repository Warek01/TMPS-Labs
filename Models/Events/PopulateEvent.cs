using TmpsLabs.Buildings;
using TmpsLabs.Models;

namespace TmpsLabs.Events;

public class PopulateEvent : BuildingEvent {
  public PopulateEvent(CityRegion region, Building b, int population) : base(region,
      EventType.Populate, b.Name, population, b) { }

  public override void Execute() {
    Region.Populate(Building, Population);
  }
}
