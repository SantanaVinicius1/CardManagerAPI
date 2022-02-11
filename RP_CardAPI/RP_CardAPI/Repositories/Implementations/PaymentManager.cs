using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Models;
using RP_CardAPI.Repositories.Interfaces;

namespace RP_CardAPI.Repositories.Implementations
{
    public class PaymentManager : IPaymentManager
    {
        public void updateBalance(Payment payment)
        {
            throw new NotImplementedException();
        }

        public PaymentDetails ValidatePayment(Payment payment)
        {
            //// check JWT


            // check Fees
            using (var db = new CardManagerEntities())
            {
                var query = (from b in db.Fees
                             select b.feeValue).First();


            }





            return new PaymentDetails();
        }
    }
}