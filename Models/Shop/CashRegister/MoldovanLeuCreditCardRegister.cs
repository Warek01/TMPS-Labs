using TMPS_Labs.Helpers;

namespace TMPS_Labs.Models.Shop.CashRegister; 

public class MoldovanLeuCreditCardRegister : CashRegister {
  public override Currency Currency { get; } = Currency.MoldovanLeu;
  private const   double   Ratio = 17.98d;

  public override void Register(double amount) {
    Printer printer = new();
    
    printer
      .NewLine()
      .Text("    ")
      .Number(1)
      .Text(" leu credit card fee to bank.");
    
    base.Register((amount - 1) / Ratio);
  }

  public override double CountUsdEquivalent() {
    return CurrencyAmount * Ratio;
  }
}
