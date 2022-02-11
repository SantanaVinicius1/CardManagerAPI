using RP_CardAPI.UsesCases;
using RP_CardAPI.Repositories.Implementations;
using RP_CardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Jwt.Filters;

namespace RP_CardAPI.Controllers
{
    public class PaymentController : ApiController
    {

        #region Properties

        private PaymentUseCase paymentUseCase = new PaymentUseCase();

        #endregion

        #region Methods
        [HttpPost]
        [JwtAuthentication]
        public HttpResponseMessage Index(string cardNumber, string cardSecurityCode, decimal purchaseValue)
        {

            Payment purchase = new Payment(cardNumber, cardSecurityCode, purchaseValue);
            PaymentDetails details;

            try
            {
                details = paymentUseCase.execute(purchase);

                return Request.CreateResponse(HttpStatusCode.OK, details.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        #endregion  
    }
}
