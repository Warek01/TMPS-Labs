namespace TMPS_Labs.Models.Shop.Stock;

public abstract class Item {
  protected readonly Shop Shop;
  
  public          string       Name     { get; set; }
  public          double       Price    { get; set; }
  public abstract ItemCategory Category { get; }

  protected Item(Shop shop, string name, double price) {
    Shop = shop;
    Name  = name;
    Price = price;
  }

  public abstract bool Sell(Person.Person     to, int count);
  public abstract bool Discount(double newPrice);
}
