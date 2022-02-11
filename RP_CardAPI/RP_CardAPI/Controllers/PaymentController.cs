using RP_CardAPI.UsesCases;
using RP_CardAPI.Repositories.Implementations;
using RP_CardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RP_CardAPI.Controllers
{
    public class PaymentController : ApiController
    {

        #region Properties

        private PaymentUseCase paymentUseCase = new PaymentUseCase(new PaymentManager());

        #endregion

        #region Methods

        public HttpResponseMessage Index(string cardNumber, decimal purchaseValue)
        {

            Payment purchase = new Payment(cardNumber, purchaseValue);

            try
            {
                paymentUseCase.execute(purchase);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }

        #endregion  
    }
}
