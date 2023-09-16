using TMPS_Labs.Helpers;

namespace TMPS_Labs.Models.Shop.CashRegister;

public class DollarCreditCardRegister : CashRegister {
  public override Currency Currency { get; } = Currency.Dollar;

  public override void Register(double amount) {
    Printer printer = new();
    
    printer
      .NewLine()
      .Text("    ")
      .Number(50)
      .Text("cent credit card fee to bank.");
    
    base.Register(amount - 0.5);
  }

  public override double CountUsdEquivalent() {
    return CurrencyAmount;
  }
}
