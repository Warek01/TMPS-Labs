namespace TMPS_Labs.Models.Shop.Stock;

public interface IItemFactory {
  string GenerateRandomName();
  IItem  CreateItem();
}
