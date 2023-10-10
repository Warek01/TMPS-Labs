using System.Collections;
using TmpsLabs.Buildings;
using TmpsLabs.Events;

namespace TmpsLabs.Models;

using EventType = BuildingEvent.EventType;

public class CityRegion : IEnumerable, IObservable<Building, EventType> {
  public readonly string Name;

  private readonly List<Building>                    _buildings   = new();
  private readonly List<Action<Building, EventType>> _subscribers = new();

  public CityRegion(string name) {
    Name = name;
  }

  public void AddBuilding(Building b) {
    _buildings.Add(b);

    foreach (var action in _subscribers) {
      action(b, EventType.Construct);
    }
  }

  public void Populate(Building b, int populationCount) {
    b.Population = populationCount;

    foreach (var action in _subscribers) {
      action(b, EventType.Populate);
    }
  }

  public void Destroy(Building b) {
    b.IsWorking = false;

    foreach (var action in _subscribers) {
      action(b, EventType.Deconstruct);
    }
  }

  public void Subscribe(Action<Building, EventType> callback) {
    _subscribers.Add(callback);
  }

  public IEnumerator GetEnumerator() {
    return new CityRegionEnumerator(_buildings);
  }
}

public class CityRegionEnumerator : IEnumerator {
  private          int             _i = -1;
  private readonly IList<Building> _buildings;

  public CityRegionEnumerator(IList<Building> buildings) {
    _buildings = buildings;
  }

  public bool MoveNext() {
    if (_i == _buildings.Count - 1) {
      return false;
    }

    _i++;

    return true;
  }

  public void Reset() {
    _i = -1;
  }

  public object Current => _buildings[_i];
}
