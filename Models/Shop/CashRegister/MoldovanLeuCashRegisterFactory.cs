namespace TMPS_Labs.Models.Shop.CashRegister;

public class MoldovanLeuCashRegisterFactory: ICashRegisterFactory {
  public ICashRegister CreateCashRegister() {
    return new MoldovanLeuCashRegister();
  }

  public ICashRegister CreateCreditCardRegister() {
    return new MoldovanLeuCreditCardRegister();
  }
}
