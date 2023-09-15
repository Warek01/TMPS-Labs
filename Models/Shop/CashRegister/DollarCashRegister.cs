namespace TMPS_Labs.Models.Shop.CashRegister; 

public class DollarCashRegister : CashRegister {
  public override Currency Currency { get; } = Currency.Dollar;

  public override double CountUsdEquivalent() {
    return CurrencyAmount;
  }
}
