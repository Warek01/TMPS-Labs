namespace TMPS_Labs.Models.Shop.CashRegister; 

public class BitcoinCreditCardRegister : CashRegister {
  public override Currency Currency { get; } = Currency.Bitcoin;

  public override void Register(double amount) {
    Console.WriteLine($"0.00189295 bitcoin credit card fee");
    base.Register(amount - 0.00189295);
  }

  public override double CountUsdEquivalent() {
    return CurrencyAmount / 26_413.50;
  }
}
