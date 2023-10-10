using TmpsLabs.Buildings;
using TmpsLabs.Models;

namespace TmpsLabs.Events;

public abstract class BuildingEvent : IBuildEvent {
  public enum EventType {
    Construct,
    Populate,
    Deconstruct
  }

  public EventType Type;

  protected readonly string     Name;
  protected readonly int        Population;
  protected readonly CityRegion Region;
  protected readonly Building   Building;

  protected BuildingEvent(CityRegion region, EventType type, string name) {
    Type   = type;
    Name   = name;
    Region = region;
  }

  protected BuildingEvent(
      CityRegion region,
      EventType  type,
      string     name,
      int        population,
      Building   building
  ) : this(region, type, name) {
    Population = population;
    Building   = building;
  }

  public abstract void Execute();
}
