using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Providers.Interfaces;
using RP_CardAPI.Models;

namespace RP_CardAPI.Providers.Implementations
{
    public class PaymentDataAccess : IPaymentDataAccess
    {
        public decimal GetFeeValue()
        {
            decimal feeValue;

            try
            {
                using (var db = new CardManagerEntities1())
                {

                    var query = (from b in db.Fees
                                 select b.feeValue).First();

                    feeValue = query.Value;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return feeValue;
        }

        public void SavePayment(Payment payment)
        {
            try
            {

                var db = new CardManagerEntities1();

                db.Payments.Add(new Payments { CardNumber = payment.cardNumber, value = payment.purchaseValue });

                db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}