namespace TMPS_Labs.Models.Shop.Stock; 

public class CpuFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomCpuName;
  }

  public override IItem CreateItem() {
    return new Cpu();
  }
}
