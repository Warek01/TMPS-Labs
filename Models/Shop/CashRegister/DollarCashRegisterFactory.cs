namespace TMPS_Labs.Models.Shop.CashRegister;

public class DollarCashRegisterFactory: ICashRegisterFactory {
  public ICashRegister CreateCashRegister() {
    return new DollarCashRegister();
  }

  public ICashRegister CreateCreditCardRegister() {
    return new DollarCreditCardRegister();
  }
}
