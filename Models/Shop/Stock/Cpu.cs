namespace TMPS_Labs.Models.Shop.Stock;

public class Cpu : Item {
  public override ItemCategory Category { get; } = ItemCategory.Hardware;

  public Cpu(Shop shop) : base(shop, "Undefined", 0) { }

  public Cpu(Shop shop, string name, double price) : base(shop, name, price) { }

  public override bool Sell(Person.Person to, int count) {
    return true;
  }

  public override bool Discount(double newPrice) {
    throw new NotImplementedException();
  }
}
