using TMPS_Labs.Helpers;
using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop;
using TMPS_Labs.Models.Shop.Stock;

namespace TMPS_Labs.Models;

public class Simulation : ISimulation {
  private readonly IShop  _shop;
  private readonly Random _random = new();

  public Simulation(IShop shop) {
    _shop = shop;
  }

  public void Run() {
    Printer printer = new();

    printer
      .Clear()
      .Text("Starting new day at ", ConsoleColor.Blue)
      .Text(_shop.Name,             ConsoleColor.Green)
      .NewLine()
      .NewLine()
      .Text("Employees: ", ConsoleColor.Blue);

    foreach (var employee in _shop.Employees) {
      printer
        .NewLine()
        .Text($"{employee.Name} ")
        .Number(employee.Age)
        .Text(" years old.");
    }

    printer
      .NewLine()
      .NewLine()
      .Text("Items:", ConsoleColor.Blue);

    foreach (var item in _shop.Warehouse) {
      printer
        .NewLine()
        .Text($"{item.Key.Name}", ConsoleColor.DarkGreen)
        .Text(item.Key.Category == ItemCategory.Software ? " (Software) " : " ")
        .Number(item.Value)
        .Text(" pcs.");
    }

    printer
      .NewLine()
      .Text("Press any key to continue.")
      .NewLine();

    Console.ReadKey(true);
    printer.Clear();

    for (int i = 0; i < _random.Next(5, 100); i++) {
      IPerson client    = _generateClient();
      IItem   item      = _pickRandomItem();
      int     count     = _random.Next(1, 5);
      double  fullPrice = item.Price * count;

      printer
        .NewLine()
        .Text("------------")
        .NewLine()
        .Text($"{client.Name} (")
        .Number(client.Age)
        .Text(" years old, ")
        .Text($"{client.Job})")
        .NewLine()
        .Text("    Buys ")
        .Number(count)
        .Text($" {item.Name} (", ConsoleColor.Green)
        .Currency(fullPrice)
        .Text(" ")
        .Number(count)
        .Text("x")
        .Currency(item.Price)
        .Text(")");

      _shop.CashRegister.Register(fullPrice);
      _shop.Warehouse[item] -= count;
      
      printer
        .NewLine()
        .Text("------------")
        .NewLine();
    }
  }

  private IPerson _generateClient() {
    IPerson client = new Client();
    client.Name = RandomName.RandomPersonName;
    client.Age  = _random.Next(12, 60);
    client.Job  = RandomName.RandomJobName;

    return client;
  }

  private IItem _pickRandomItem() {
    return _shop.Warehouse.Keys.ToArray()[_random.Next(0, _shop.Warehouse.Keys.Count)];
  }
}
