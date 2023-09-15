namespace TMPS_Labs.Models.Shop.CashRegister;

public interface ICashRegister {
  Currency Currency       { get; }
  double   CurrencyAmount { get; }
  void     Register(double amount);
  double   CountUsdEquivalent();
}
