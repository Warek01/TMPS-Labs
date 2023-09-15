namespace TMPS_Labs.Models.Shop.CashRegister;

public abstract class CashRegister : ICashRegister {
  public abstract Currency Currency { get; }

  public double CurrencyAmount { get; private set; }

  public virtual void Register(double amount) {
    CurrencyAmount += amount;
  }

  public abstract double CountUsdEquivalent();
}
