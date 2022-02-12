using Newtonsoft.Json;
using RestSharp;
using RP_CardAPI.Models;
using RP_CardAPI.UsesCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
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
        public CardInfo Index()
        {
            var rParams = HttpContext.Current.Request.Form;
            int cardID = Convert.ToInt32(rParams.Get("cardID") == "" ? "0" : rParams.Get("cardID"));

            try
            {
                return createCardUseCase.execute(cardID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
