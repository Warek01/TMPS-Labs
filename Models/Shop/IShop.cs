using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop.CashRegister;
using TMPS_Labs.Models.Shop.Stock;

namespace TMPS_Labs.Models.Shop;

public interface IShop {
  string                 Name         { get; }
  List<IPerson>          Employees    { get; }
  Dictionary<IItem, int> Warehouse    { get; }
  ICashRegister          CashRegister { get; }
}
