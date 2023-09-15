namespace TMPS_Labs.Models.Shop.Stock; 

public class RamFactory : ItemFactory {
  public override Item CreateItem(Shop shop) {
    return new Ram(shop);
  }
}
