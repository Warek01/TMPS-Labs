using TMPS_Labs.Helpers;
using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop;
using TMPS_Labs.Models.Shop.CashRegister;
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
        .Text(").");

      int availCount = _shop.Warehouse[item];

      if (availCount == 0) {
        printer
          .NewLine()
          .Text("    Could not buy ")
          .Text(item.Name, ConsoleColor.Green)
          .Text(" (out of stock).");
      }
      else if (availCount < count) {
        int diff = availCount - count;
        fullPrice             = diff * count;
        _shop.Warehouse[item] = 0;

        printer
          .NewLine()
          .Text("    ")
          .Text(item.Name, ConsoleColor.Green)
          .Text(" has finished in stock.");
        
        _shop.CashRegister.Register(fullPrice);
      }
      else {
        _shop.Warehouse[item] -= count;
        _shop.CashRegister.Register(fullPrice);
      }


      printer
        .NewLine()
        .Text("------------")
        .NewLine();
    }

    string currency = _shop.CashRegister.Currency switch {
      Currency.Bitcoin     => "Bitcoins",
      Currency.MoldovanLeu => "Leis",
      Currency.Dollar      => "Dollars",
      _                    => "Dollars",
    };

    printer
      .NewLine()
      .NewLine()
      .Text("At the end of day ")
      .Text(_shop.Name, ConsoleColor.Green)
      .Text(" earned ")
      .Number(_shop.CashRegister.CurrencyAmount)
      .Text($" {currency} or ")
      .Currency(_shop.CashRegister.CountUsdEquivalent());
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
