namespace TMPS_Labs.Models.Shop.Stock; 

public class CpuFactory : ItemFactory {
  public override Item CreateItem(Shop shop) {
    return new Cpu(shop);
  }
}
