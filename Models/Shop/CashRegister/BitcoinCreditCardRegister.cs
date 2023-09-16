using TMPS_Labs.Helpers;

namespace TMPS_Labs.Models.Shop.CashRegister;

public class BitcoinCreditCardRegister : CashRegister {
  public override Currency Currency { get; } = Currency.Bitcoin;
  private const   double   Ratio = 26_413.50d;

  public override void Register(double amount) {
    Printer printer = new();

    printer
      .NewLine()
      .Text("    ")
      .Number(20 / Ratio)
      .Text(" bitcoin credit card fee to bank.");

    base.Register((amount - 20) / Ratio);
  }

  public override double CountUsdEquivalent() {
    return CurrencyAmount * Ratio;
  }
}
