namespace TMPS_Labs.Models.Shop.Stock;

public abstract class ItemFactory : IItemFactory {
  public abstract string GenerateRandomName();
  public abstract IItem  CreateItem();
}
