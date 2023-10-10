namespace TmpsLabs.Building;

public static class BuildingFactory {


  public static Building CreateBuilding(BuildingType type) {
    return type switch {
        BuildingType.Residential   => new Residential(),
        BuildingType.PoliceStation => new PoliceStation(),
        BuildingType.Hospital      => new Hospital(),
        BuildingType.Mall          => new Mall(),
    };
  }
}
