namespace TMPS_Labs.Models.Shop.CashRegister;

public class MoldovanLeuCashRegister : CashRegister {
  public override Currency Currency { get; } = Currency.MoldovanLeu;
  private const   double   Ratio = 17.98d;

  public override double CountUsdEquivalent() {
    return CurrencyAmount * Ratio;
  }
}
