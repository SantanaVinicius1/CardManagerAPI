using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Models;
using RP_CardAPI.Repositories.Interfaces;
using RP_CardAPI.Providers.Interfaces;
using RP_CardAPI.Providers;

namespace RP_CardAPI.Repositories.Implementations
{
    public class PaymentManager : IPaymentManager
    {

        IPaymentDataAccess _paymentDataAccess;
        ICardDataAccess _cardDataAccess;

        public PaymentManager()
        {
            _paymentDataAccess = PaymentDataAccessFactory.GetPaymentDataAcessObj();
            _cardDataAccess = CardDataAccessFactory.getCardDataAccessObj();
        }

        public void SavePayment(Payment payment)
        {
            _paymentDataAccess.SavePayment(payment);
            _cardDataAccess.UpdateCardBalance(payment.cardNumber, (payment.purchaseValue + _paymentDataAccess.GetFeeValue()));
        }

        public PaymentDetails ValidatePayment(Payment payment)
        {
            PaymentDetails details = new PaymentDetails(true, "Payment ok!");
            decimal balance;
            
            
            balance = _cardDataAccess.GetCardBalance(payment.cardNumber);
            decimal valueWithFee = payment.purchaseValue + _paymentDataAccess.GetFeeValue();

            if(!_cardDataAccess.CheckSecurityCode(payment.cardNumber, payment.cardSecurityCode))
            {
                details.Success = false;
                details.Message = "Invalid Card Security Code";

                return details;
            }

            if(valueWithFee > balance)
            {
                details.Success = false;
                details.Message = "Insuficient funds!";

                return details;
            }
            
            return details;
        }

    }
}