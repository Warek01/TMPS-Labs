namespace TMPS_Labs.Models.Shop.Stock; 

public class SoftwareFactory : ItemFactory {
  public override Item CreateItem(Shop shop) {
    return new Software(shop);
  }
}
