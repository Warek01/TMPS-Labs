using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop.CashRegister;
using TMPS_Labs.Models.Shop.Stock;

namespace TMPS_Labs.Models.Shop;

public class Shop : IShop {
  public string                 Name         { get; }
  public List<Employee>         Employees    { get; }
  public Dictionary<IItem, int> Warehouse    { get; }
  public ICashRegister          CashRegister { get; }

  public List<Employee> WorkingEmployees { get; } = new();

  public Shop(
    string                 name,
    List<Employee>         employees,
    Dictionary<IItem, int> warehouse,
    ICashRegister          cashRegister
  ) {
    Name         = name;
    Employees    = employees;
    Warehouse    = warehouse;
    CashRegister = cashRegister;
  }

  public Employee AllocateEmployee() {
    throw new NotImplementedException();
  }

  private Employee HireTemporaryEmployee() {
    throw new NotImplementedException();
  }
}
