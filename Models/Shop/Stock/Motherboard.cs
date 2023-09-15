namespace TMPS_Labs.Models.Shop.Stock;

public class Motherboard : Item {
  public override ItemCategory Category { get; } = ItemCategory.Hardware;

  public Motherboard(Shop shop) : base(shop, "Undefined", 0) { }

  public Motherboard(Shop shop, string name, double price) : base(shop, name, price) { }

  public override bool Sell(Person.Person to, int count) {
    return true;
  }

  public override bool Discount(double newPrice) {
    throw new NotImplementedException();
  }
}
