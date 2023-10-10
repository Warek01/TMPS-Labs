namespace TmpsLabs.Events;

public class ConstructEvent : BuildingEvent {
  public ConstructEvent(string name) : base(EventType.Construct, name) { }

  public override void Execute() { }
}
