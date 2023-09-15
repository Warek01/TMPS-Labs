namespace TMPS_Labs.Models.Shop.CashRegister;

public interface ICashRegisterFactory {
  ICashRegister CreateCashRegister();
  ICashRegister CreateCreditCardRegister();
}
