namespace TMPS_Labs.Models.Shop.Stock;

public class GpuFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomGpuName;
  }

  public override IItem CreateItem() {
    return new Gpu();
  }
}
