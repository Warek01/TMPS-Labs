namespace TmpsLabs.Events;

public abstract class BuildingEvent : IBuildEvent {
  public enum EventType {
    Construct,
    Populate,
    Deconstruct
  }

  public EventType Type;
  public string    Name;
  public int?      Population;

  protected BuildingEvent(EventType type, string name) {
    Type = type;
    Name = name;
  }

  protected BuildingEvent(EventType type, string name, int population) : this(type, name) {
    Population = population;
  }

  public abstract void Execute();
}
