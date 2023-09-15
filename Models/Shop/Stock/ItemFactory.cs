namespace TMPS_Labs.Models.Shop.Stock; 

public abstract class ItemFactory {
  public abstract Item CreateItem(Shop shop);
}
