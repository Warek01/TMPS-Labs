namespace TmpsLabs.Events;

public class DeconstructEvent : BuildingEvent {
  public DeconstructEvent(string name) : base(EventType.Deconstruct, name) { }

  public override void Execute() { }
}
