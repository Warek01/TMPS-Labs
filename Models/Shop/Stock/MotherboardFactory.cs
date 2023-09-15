namespace TMPS_Labs.Models.Shop.Stock; 

public class MotherboardFactory : ItemFactory {
  public override Item CreateItem(Shop shop) {
    return new Motherboard(shop);
  }
}
