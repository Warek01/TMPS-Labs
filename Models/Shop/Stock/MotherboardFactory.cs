namespace TMPS_Labs.Models.Shop.Stock;

public class MotherboardFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomMotherboardName;
  }

  public override IItem CreateItem() {
    return new Motherboard();
  }
}
