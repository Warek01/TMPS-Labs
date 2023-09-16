using TMPS_Labs.Models.Person;

namespace TMPS_Labs.Models.Shop.Stock;

public class Cpu : Item {
  public override ItemCategory Category { get; } = ItemCategory.Hardware;

  public Cpu() : base("Undefined", 0) { }

  public Cpu(string name, double price) : base(name, price) { }

  public override bool Sell(IPerson to, int count) {
    return true;
  }

  public override bool Discount(double newPrice) {
    throw new NotImplementedException();
  }
}
