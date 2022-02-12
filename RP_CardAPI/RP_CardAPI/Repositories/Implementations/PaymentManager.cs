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
            _cardDataAccess.UpdateCardBalance(payment.CardID, (payment.PaymentValue + _paymentDataAccess.GetFeeValue()));
        }

        public PaymentDetails ValidatePayment(Payment payment)
        {
            PaymentDetails details = new PaymentDetails(true, "Payment ok!");
            decimal balance;
            
            
            balance = _cardDataAccess.GetCardBalance(payment.CardID).CardBalance;
            decimal valueWithFee = payment.PaymentValue + _paymentDataAccess.GetFeeValue();


            if(valueWithFee > balance)
            {
                details.Success = false;
                details.Message = $"Insuficient funds! \r\n Payment value with Fees: {valueWithFee} \r\n Card balance: {balance}";

                return details;
            }
            
            return details;
        }

    }
}