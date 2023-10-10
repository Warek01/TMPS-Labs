using TmpsLabs.Buildings;
using TmpsLabs.Models;

namespace TmpsLabs.Events;

public class DeconstructEvent : BuildingEvent {
  public DeconstructEvent(CityRegion region, Building b) : base(region, EventType.Deconstruct, b.Name) { }

  public override void Execute() {
    Region.Destroy(Building);
  }
}
