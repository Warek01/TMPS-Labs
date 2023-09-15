namespace TMPS_Labs.Models.Shop.Stock; 

public class GpuFactory : ItemFactory {
  public override Item CreateItem(Shop shop) {
    return new Gpu(shop);
  }
}
