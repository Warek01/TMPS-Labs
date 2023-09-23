using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop.CashRegister;
using TMPS_Labs.Models.Shop.Stock;

namespace TMPS_Labs.Models.Shop;

public class ShopBuilder : IShopBuilder {
  private string        _name         = null!;
  private ICashRegister _cashRegister = null!;

  private readonly Dictionary<IItem, int> _items     = new();
  private readonly List<IPerson>          _employees = new();

  public ShopBuilder() {
    Console.WriteLine("Registering a new shop!");
  }

  public ShopBuilder SetName(string name) {
    _name = name;
    return this;
  }

  public ShopBuilder AddItem(IItem item, int count) {
    _items[item] = count;
    return this;
  }

  public ShopBuilder AddEmployee(IPerson employee) {
    _employees.Add(employee);
    return this;
  }

  public ShopBuilder SetCashRegister(ICashRegister cashRegister) {
    _cashRegister = cashRegister;
    return this;
  }

  public Shop Build() {
    return new Shop(_name, _employees, _items, _cashRegister);
  }
}
