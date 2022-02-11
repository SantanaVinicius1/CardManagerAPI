using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Models;
using RP_CardAPI.Repositories;
using RP_CardAPI.Repositories.Implementations;
using RP_CardAPI.Repositories.Interfaces;

namespace RP_CardAPI.UsesCases
{
    public class PaymentUseCase 
    {

        #region Properties

        IPaymentManager paymentManager;

        #endregion

        #region Constructor

        public PaymentUseCase()
        {
            paymentManager = new PaymentManager();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Exec the payment 
        /// </summary>
        public PaymentDetails execute(Payment purchase)
        {

            //Check if the payment is valid
            PaymentDetails paymentDetail = paymentManager.ValidatePayment(purchase);

            if (paymentDetail.Success)
            {
                //if the payment is valid then update the balance

                paymentManager.SavePayment(purchase);
               


                return paymentDetail;
            }
            else
            {
                //if not, then return the invalid message

                return paymentDetail;
            }


        }

        #endregion
    }
}