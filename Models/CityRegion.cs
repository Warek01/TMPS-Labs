using System.Collections;

namespace TmpsLabs.Models;

using Building = TmpsLabs.Building.Building;

public class CityRegion : IEnumerable {
  public readonly  string         Name;
  private readonly List<Building> _buildings = new();

  public CityRegion(string name) {
    Name = name;
  }

  public void AddBuilding(Building b) {
    _buildings.Add(b);
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
