using TMPS_Labs.Models.Person;

namespace TMPS_Labs.Models.Shop.Stock;

public class Software : Item {
  public override ItemCategory Category { get; } = ItemCategory.Hardware;

  public Software() : base("Undefined", 0) { }

  public Software(string name, double price) : base(name, price) { }

  public override bool Sell(IPerson to, int count) {
    return true;
  }

  public override bool Discount(double newPrice) {
    throw new NotImplementedException();
  }
}
