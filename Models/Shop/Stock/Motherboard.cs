using TMPS_Labs.Models.Person;

namespace TMPS_Labs.Models.Shop.Stock;

public class Motherboard : Item {
  public override ItemCategory Category { get; } = ItemCategory.Hardware;

  public Motherboard() : base("Undefined", 0) { }

  public Motherboard(string name, double price) : base(name, price) { }

  public override bool Sell(IPerson to, int count) {
    return true;
  }

  public override bool Discount(double newPrice) {
    throw new NotImplementedException();
  }
}
