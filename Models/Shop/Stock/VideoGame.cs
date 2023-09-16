using TMPS_Labs.Helpers;
using TMPS_Labs.Models.Person;

namespace TMPS_Labs.Models.Shop.Stock;

public class VideoGame : Item {
  public override ItemCategory Category { get; } = ItemCategory.Software;

  public int FromAge { get; set; }

  public VideoGame() : base("Undefined", 0) { }

  public VideoGame(string name, double price, int fromAge) : base(name, price) {
    FromAge = fromAge;
  }

  public override bool Sell(IPerson to, int count) {
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
