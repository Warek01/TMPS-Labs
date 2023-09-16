namespace TMPS_Labs.Models.Shop.Stock; 

public class RamFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomRamName;
  }
  
  public override IItem CreateItem() {
    return new Ram();
  }
}
