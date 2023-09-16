using TMPS_Labs.Models.Shop;

namespace TMPS_Labs.Models;

public class Simulation {
  private IShop _shop;

  public Simulation(IShop shop) {
    _shop = shop;
  }

  public void Run() { }
}
