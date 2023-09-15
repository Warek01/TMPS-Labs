namespace TMPS_Labs.Models.Shop.CashRegister; 

public class MoldovanLeuCreditCardRegister : CashRegister {
  public override Currency Currency { get; } = Currency.Dollar;

  public override void Register(double amount) {
    Console.WriteLine($"1 leu credit card fee to bank.");
    base.Register(amount - 1);
  }

  public override double CountUsdEquivalent() {
    return CurrencyAmount * 17.98;
  }
}
