namespace TMPS_Labs.Models.Shop.CashRegister; 

public class DollarCreditCardRegister : CashRegister {
  public override Currency Currency { get; } = Currency.Dollar;

  public override void Register(double amount) {
    Console.WriteLine($"50 cent credit card fee to bank.");
    base.Register(amount - 0.5);
  }

  public override double CountUsdEquivalent() {
    return CurrencyAmount;
  }
}
