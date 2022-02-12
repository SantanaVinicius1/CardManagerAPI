using RP_CardAPI.UsesCases;
using RP_CardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Jwt.Filters;
using System.Web;

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
        public PaymentDetails Index()
        {
            var rParams = HttpContext.Current.Request.Form;
            int cardID = Convert.ToInt32(rParams.Get("cardID") == "" ? "0" : rParams.Get("cardID"));
            decimal paymentValue = Convert.ToInt32(rParams.Get("paymentValue") == "" ? "0" : rParams.Get("paymentValue"));

            Payment payment = new Payment(cardID, paymentValue);
            PaymentDetails details = new PaymentDetails();

            try
            {
                if(cardID <= 0 || paymentValue <= 0)
                {
                    details.Success = false;
                    details.Message = "Invalid payment information";
                }

                details = paymentUseCase.execute(payment);

                return details;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion  
    }
}
