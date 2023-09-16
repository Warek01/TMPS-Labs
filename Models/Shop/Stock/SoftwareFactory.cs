namespace TMPS_Labs.Models.Shop.Stock; 

public class SoftwareFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomSoftwareName;
  }
  
  public override IItem CreateItem() {
    return new Software();
  }
}
