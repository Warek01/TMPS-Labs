namespace TMPS_Labs.Models.Shop.Stock; 

public class VideoGameFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomVideoGameName;
  }
  
  public override IItem CreateItem() {
    return new VideoGame();
  }
}
