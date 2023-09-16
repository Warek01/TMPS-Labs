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

IShop      shop       = shopBuilder.Build();
Simulation simulation = new(shop);
simulation.Run();

return;

void SelectCashRegister(IShopBuilder shopBuilder) {
  bool isCash = GraphicHelper.SelectMultipleChoice<bool>(
    new List<KeyValuePair<bool, string>>(
      new[] {
        new KeyValuePair<bool, string>(true,  "Cash"),
        new KeyValuePair<bool, string>(false, "Credit card"),
      }
    ),
    title: "How will the shop accept currency?"
  );

  Currency currency = GraphicHelper.SelectMultipleChoice<Currency>(
    new List<KeyValuePair<Currency, string>>(
      new[] {
        new KeyValuePair<Currency, string>(Currency.Dollar,      "Dollars"),
        new KeyValuePair<Currency, string>(Currency.MoldovanLeu, "Moldovan leis"),
        new KeyValuePair<Currency, string>(Currency.Bitcoin,     "Bitcoins"),
      }
    ),
    title: "What currency will shop accept?"
  );

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
  ConsoleKeyInfo keyInfo;

  do {
    Console.Clear();
    IItem item;

    SelectForm<IItemFactory> factoryForm = new();
    factoryForm
      .Title("Select a product")
      .Vertical()
      .Width(20)
      .AddOption(new CpuFactory(),         "CPU")
      .AddOption(new GpuFactory(),         "GPU")
      .AddOption(new MotherboardFactory(), "Motherboard")
      .AddOption(new RamFactory(),         "RAM")
      .AddOption(new SoftwareFactory(),    "Software")
      .AddOption(new VideoGameFactory(),   "Video Game");

    IItemFactory factory = factoryForm.Render();
    item = factory.CreateItem();

    SelectForm<bool> isManualForm = new();
    isManualForm
      .Title("How to insert the product?")
      .Horizontal()
      .AddOption(false, "Random")
      .AddOption(true,  "manual");

    bool isManual = isManualForm.Render();

    int count;

    if (isManual) {
      printer
        .SetFg(ConsoleColor.Blue)
        .NewLine()
        .Text("Name = ")
        .Prompt(out string name)
        .NewLine()
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
