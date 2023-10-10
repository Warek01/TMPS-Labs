namespace TmpsLabs.Events;

public class PopulateEvent : BuildingEvent {
  public PopulateEvent(string name, int population) : base(EventType.Populate, name, population) { }

  public override void Execute() { }
}
