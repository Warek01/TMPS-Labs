namespace TMPS_Labs.Models.Shop.Stock; 

public class VideoGameFactory : ItemFactory {
  public override Item CreateItem(Shop shop) {
    return new VideoGame(shop);
  }
}
