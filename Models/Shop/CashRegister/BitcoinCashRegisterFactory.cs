namespace TMPS_Labs.Models.Shop.CashRegister;

public class BitcoinCashRegisterFactory : ICashRegisterFactory {
  public ICashRegister CreateCashRegister() {
    return new BitcoinCashRegister();
  }

  public ICashRegister CreateCreditCardRegister() {
    return new BitcoinCreditCardRegister();
  }
}
