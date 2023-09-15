namespace TMPS_Labs.Models.Shop.CashRegister;

public class MoldovanLeuCashRegister : CashRegister {
  public override Currency Currency { get; } = Currency.MoldovanLeu;

  public override double CountUsdEquivalent() {
    return CurrencyAmount * 17.98;
  }
}
