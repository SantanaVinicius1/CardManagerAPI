using RP_CardAPI.UsesCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Jwt.Filters;

namespace RP_CardAPI.Controllers
{
    public class GetBalanceController : ApiController
    {

        #region Properties

        private GetBalanceUseCase createCardUseCase = new GetBalanceUseCase();

        #endregion

        #region Methods

        [HttpPost]
        [JwtAuthentication]
        public HttpResponseMessage Index(string cardNumber)
        {
            decimal balance;
            try
            {
                balance = createCardUseCase.execute(cardNumber);

                return Request.CreateResponse(HttpStatusCode.OK, balance.ToString());
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
    }
}
