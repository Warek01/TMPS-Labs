namespace TMPS_Labs.Models.Shop.CashRegister; 

public class BitcoinCashRegister : CashRegister {
  public override Currency Currency { get; } = Currency.Bitcoin;

  public override void Register(double amount) {
    Console.WriteLine($"0.000757189 bitcoin fee");
    base.Register(amount - 0.000757189);
  }

  public override double CountUsdEquivalent() {
    return CurrencyAmount / 26_413.50;
  }
}
