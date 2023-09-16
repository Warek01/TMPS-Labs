using TMPS_Labs.Helpers;
using TMPS_Labs.Models;
using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop;
using TMPS_Labs.Models.Shop.CashRegister;
using TMPS_Labs.Models.Shop.Stock;

Random       random      = new();
Printer      printer     = new();
IShopBuilder shopBuilder = new ShopBuilder();

SelectShopName(shopBuilder);
SelectCashRegister(shopBuilder);
GenerateEmployees(shopBuilder);
GenerateItems(shopBuilder);

IShop       shop       = shopBuilder.Build();
ISimulation simulation = new Simulation(shop);
simulation.Run();

return;

void SelectCashRegister(IShopBuilder shopBuilder) {
  bool isCash = new SelectForm<bool>()
                .Title("How will the shop accept currency?")
                .AddOption(true,  "Cash")
                .AddOption(false, "Credit card")
                .Render();

  Currency currency = new SelectForm<Currency>()
                      .Title("What currency will shop accept?")
                      .AddOption(Currency.Dollar,      "Dollars")
                      .AddOption(Currency.Bitcoin,     "Bitcoins")
                      .AddOption(Currency.MoldovanLeu, "Moldovan leis")
                      .Render();

  ICashRegisterFactory cashRegisterFactory = currency switch {
    Currency.Dollar      => new DollarCashRegisterFactory(),
    Currency.MoldovanLeu => new MoldovanLeuCashRegisterFactory(),
    Currency.Bitcoin     => new BitcoinCashRegisterFactory(),
    _                    => new DollarCashRegisterFactory()
  };

  ICashRegister cashRegister = isCash switch {
    true  => cashRegisterFactory.CreateCashRegister(),
    false => cashRegisterFactory.CreateCreditCardRegister()
  };

  shopBuilder.SetCashRegister(cashRegister);
}

void GenerateEmployees(IShopBuilder shopBuilder) {
  Console.Clear();
  GraphicHelper.ColorPrint("How much employees does the shop have?\n", fg: ConsoleColor.Blue);

  int nr = Convert.ToInt32(Console.ReadLine()!);

  for (int i = 0; i < nr; i++) {
    Employee employee = new() {
      Age  = random.Next(18, 60),
      Name = RandomName.RandomPersonName,
      Job  = "Employee"
    };
    shopBuilder.AddEmployee(employee);
  }
}

void SelectShopName(IShopBuilder shopBuilder) {
  printer
    .Text("Shop name = ")
    .Prompt(out string shopName)
    .Clear();

  shopBuilder.SetName(shopName);
}

void GenerateItems(IShopBuilder shopBuilder) {
  bool isFullRandom = new SelectForm<bool>()
                      .Title("Would you like to randomize products or insert them manually?")
                      .AddOption(true,  "Full random")
                      .AddOption(false, "All manually")
                      .Render();

  if (isFullRandom) {
    IItemFactory[] allFactories = {
      new CpuFactory(),
      new GpuFactory(),
      new RamFactory(),
      new MotherboardFactory(),
      new SoftwareFactory(),
      new VideoGameFactory(),
    };

    foreach (IItemFactory factory in allFactories) {
      for (int i = 0; i < random.Next(1, 10); i++) {
        IItem item = factory.CreateItem();
        item.Name  = factory.GenerateRandomName();
        item.Price = random.Next(20, 1000);
        int count = random.Next(1, 50);

        shopBuilder.AddItem(item, count);
      }
    }

    return;
  }

  ConsoleKeyInfo keyInfo;
  do {
    Console.Clear();
    IItem item;
    IItemFactory factory = new SelectForm<IItemFactory>()
                           .Title("Select a product")
                           .Vertical()
                           .Width(20)
                           .AddOption(new CpuFactory(),         "CPU")
                           .AddOption(new GpuFactory(),         "GPU")
                           .AddOption(new MotherboardFactory(), "Motherboard")
                           .AddOption(new RamFactory(),         "RAM")
                           .AddOption(new SoftwareFactory(),    "Software")
                           .AddOption(new VideoGameFactory(),   "Video Game")
                           .Render();

    item = factory.CreateItem();
    bool isManual = new SelectForm<bool>()
                    .Title("How to insert the product?")
                    .Horizontal()
                    .AddOption(false, "Random")
                    .AddOption(true,  "Manual")
                    .Render();

    int count;

    if (isManual) {
      printer
        .SetFg(ConsoleColor.Blue)
        .NewLine()
        .Text("Name = ")
        .Prompt(out string name)
        .Text("Count = ")
        .PromptInt(out count)
        .Text("Price = ")
        .PromptDouble(out double price)
        .NewLine();

      item.Name  = name;
      item.Price = price;
    }
    else {
      item.Name  = factory.GenerateRandomName();
      item.Price = random.Next(20, 1000);
      count      = random.Next(1,  50);
    }

    shopBuilder.AddItem(item, count);
    printer
      .NewLine()
      .Text(item.Name, ConsoleColor.Green)
      .Text(" (")
      .Number(count)
      .Text(") pcs. at price ")
      .Number(item.Price)
      .Text(" per unit.")
      .NewLine()
      .NewLine()
      .Text("Press ")
      .Text("Space", ConsoleColor.Green)
      .Text(" to finnish or ")
      .Text("Enter", ConsoleColor.Green)
      .Text(" to continue.")
      .NewLine();

    keyInfo = Console.ReadKey();
  } while (keyInfo.Key != ConsoleKey.Spacebar);
}
