# Topic: *Creational Design Patterns*

## Author: 
*Dobrojan Alexandru* FAF-212

------
## Objectives:
1. Study and understand the Creational Design Patterns.

2. Choose a domain, define its main classes/models/entities and choose the appropriate instantiation mechanisms.

3. Use some creational design patterns for object instantiation in a sample project.

## Main tasks:
1. Choose an OO programming language and a suitable IDE or Editor (No frameworks/libs/engines allowed).

2. Select a domain area for the sample project.

3. Define the main involved classes and think about what instantiation mechanisms are needed.

4. Based on the previous point, implement at least 2 creational design patterns in your project.

## Implementation
The theme of my project is simulating a computer shop. I used singleton, builder, prototype, factory, abstract factory creational design patterns.

1. Singleton
The Shop class defined by IShop interface. Is instantiated once in program and used in the entire simulation until the end
```csharp
public class Shop : IShop {
  public string                 Name         { get; }
  public List<IPerson>          Employees    { get; }
    
... Program.cs
IShop       shop       = shopBuilder.Build();
ISimulation simulation = new Simulation(shop);
simulation.Run();
```

2. Builder
There is a ShopBuilder class that builds the Shop class, since the shop requires 4 constructor parameters that should be set up before starting simulation
```csharp
public class ShopBuilder : IShopBuilder {
  private string        _name         = null!;

...
    
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
    
... Program.cs
IShopBuilder shopBuilder = new ShopBuilder();

SelectShopName(shopBuilder);
SelectCashRegister(shopBuilder);
GenerateEmployees(shopBuilder);
GenerateItems(shopBuilder);
IShop shop = shopBuilder.Build();
```

3. Prototype
I have an interface IClonable that is implemented by Person class. I use it to clone Employees of shop at initialization
```csharp
public interface IClonable<T> {
  T Clone();
}

... Emplyee.cs
public class Employee : Person {
  public override IPerson Clone() {
    return new Employee {
      Age = Age,
      Job = Job,
      Name = Name
    };
  }
}

... Program.cs
IPerson employee = new Employee {
    Job = "Employee"
};

for (int i = 0; i < nr; i++) {
    IPerson newEmployee = employee.Clone();
    newEmployee.Age  = random.Next(18, 60);
    newEmployee.Name = RandomName.RandomPersonName;
    shopBuilder.AddEmployee(newEmployee);
}
```

4. Factory
There is a ItemFactory class that generates a concrete computer item by IItem interface. Each item has name,
category, price and count in stock.
```csharp
public abstract class ItemFactory : IItemFactory {
  public abstract string GenerateRandomName();
  public abstract IItem  CreateItem();
}

public class GpuFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomGpuName;
  }

  public override IItem CreateItem() {
    return new Gpu();
  }
}

public class CpuFactory : ItemFactory {
  public override string GenerateRandomName() {
    return RandomName.RandomCpuName;
  }

  public override IItem CreateItem() {
    return new Cpu();
  }
}

... Ram.cs
public class Ram : Item {
  public override ItemCategory Category { get; } = ItemCategory.Hardware;

  public Ram() : base("Undefined", 0) { }

  public Ram(string name, double price) : base(name, price) { }

  public override bool Sell(IPerson to, int count) {
    return true;
  }

  public override bool Discount(double newPrice) {
    throw new NotImplementedException();
  }
}
```

5. Abstract factory
I have CashRegister class, cash register may be of 3 currencies, dollar, moldovan leu and bitcoin. Also it can be of 2 types: cash and credit card.
The cash register abstract factory defines the cash register subclasses into currencies.
```csharp
public interface ICashRegister {
  Currency Currency       { get; }
  double   CurrencyAmount { get; }
  void     Register(double amount);
  double   CountUsdEquivalent();
}

public class MoldovanLeuCashRegisterFactory: ICashRegisterFactory {
  public ICashRegister CreateCashRegister() {
    return new MoldovanLeuCashRegister();
  }

  public ICashRegister CreateCreditCardRegister() {
    return new MoldovanLeuCreditCardRegister();
  }
}

public class DollarCashRegisterFactory: ICashRegisterFactory {
  public ICashRegister CreateCashRegister() {
    return new DollarCashRegister();
  }

  public ICashRegister CreateCreditCardRegister() {
    return new DollarCreditCardRegister();
  }
}
```


# Conclusions / Screenshots / Results
Creational design patterns ease the work of the developer when it comes to simulating or other code that involves working with a large
amount of classes, especially then there are types of classes and subclasses and categories.

![name.png](Images%2Fname.png)

![employees.png](Images%2Femployees.png)

![currency.png](Images%2Fcurrency.png)

![credit-card.png](Images%2Fcredit-card.png)

![pre-simulation.png](Images%2Fpre-simulation.png)

![results.png](Images%2Fresults.png)

