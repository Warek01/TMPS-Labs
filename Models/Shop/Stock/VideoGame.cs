namespace TMPS_Labs.Models.Shop.Stock;

public class VideoGame : Item {
  public override ItemCategory Category { get; } = ItemCategory.Software;

  public int FromAge { get; set; }

  public VideoGame(Shop shop) : base(shop, "Undefined", 0) { }

  public VideoGame(Shop shop, string name, double price, int fromAge) : base(shop, name, price) {
    FromAge = fromAge;
  }

  public override bool Sell(Person.Person to, int count) {
    if (to.Age < FromAge) {
      GraphicHelper.ColorPrint($"{to.Name} is too young to buy {Name} ({count} pcs.)");
      return false;
    }

    return true;
  }

  public override bool Discount(double newPrice) {
    throw new NotImplementedException();
  }
}
