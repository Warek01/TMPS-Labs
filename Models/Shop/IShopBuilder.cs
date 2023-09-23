using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop.CashRegister;
using TMPS_Labs.Models.Shop.Stock;

namespace TMPS_Labs.Models.Shop;

public interface IShopBuilder {
  ShopBuilder SetName(string                name);
  ShopBuilder AddItem(IItem                 item, int count);
  ShopBuilder AddEmployee(IPerson           employee);
  ShopBuilder SetCashRegister(ICashRegister cashRegister);
  Shop        Build();
}
