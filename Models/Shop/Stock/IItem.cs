using TMPS_Labs.Models.Person;

namespace TMPS_Labs.Models.Shop.Stock;

public interface IItem {
  string       Name     { get; set; }
  double       Price    { get; set; }
  ItemCategory Category { get; }

  bool Sell(IPerson to, int count);
  bool Discount(double    newPrice);
}
