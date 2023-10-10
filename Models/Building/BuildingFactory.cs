namespace TmpsLabs.Buildings;

public static class BuildingFactory {
  public static Building CreateBuilding(BuildingType type) {
    return type switch {
        BuildingType.Residential   => new Residential(),
        BuildingType.PoliceStation => new PoliceStation(),
        BuildingType.Hospital      => new Hospital(),
        BuildingType.Mall          => new Mall(),
    };
  }

  public static Building CreateRandomBuilding() {
    var rand = new Random();

    return rand.Next(4) switch {
        0 => new Residential(),
        1 => new PoliceStation(),
        2 => new Hospital(),
        3 or _ => new Mall(),
    };
  }
}
