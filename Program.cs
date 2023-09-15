using TMPS_Labs.Models;
using TMPS_Labs.Models.Person;
using TMPS_Labs.Models.Shop;
using TMPS_Labs.Models.Shop.CashRegister;
using TMPS_Labs.Models.Shop.Stock;

IShopBuilder shopBuilder = new ShopBuilder();
GraphicHelper.ColorPrint("Select a name for the computer shop\n", fg: ConsoleColor.Blue);
shopBuilder.SetName(
  Console.ReadLine()!
);
SelectCashRegister(shopBuilder);

var employeesList = new List<Employee>();

var warehouse = new Dictionary<Item, int>(
//   new[] {
//   new KeyValuePair<Item, int>()
// }
);

IShop shop = shopBuilder.Build();

employeesList.AddRange(new[] {
  new Employee {
    Name = "Joe",
    Age  = 21,
  },
  new Employee {
    Name = "Alex",
    Age  = 29,
  },
  new Employee {
    Name = "Mary",
    Age  = 20,
  },
  new Employee {
    Name = "Denis",
    Age  = 30,
  },
  new Employee {
    Name = "Anna",
    Age  = 31,
  },
});
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
