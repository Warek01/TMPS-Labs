using TMPS_Labs.Models.Person;

namespace TMPS_Labs.Models.Shop.Stock;

public abstract class Item : IItem {
  public          string       Name     { get; set; }
  public          double       Price    { get; set; }
  public abstract ItemCategory Category { get; }

  protected Item(string name, double price) {
    Name  = name;
    Price = price;
  }

  public abstract bool Sell(IPerson     to, int count);
  public abstract bool Discount(double newPrice);
}
