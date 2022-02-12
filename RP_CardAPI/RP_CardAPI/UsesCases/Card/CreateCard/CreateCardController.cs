using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RP_CardAPI.UsesCases;
using RP_CardAPI.Models;
using System.Net.Http;
using System.Net;
using WebApi.Jwt.Filters;

namespace RP_CardAPI.Controllers
{
    
    public class CreateCardController : ApiController
    {
        #region Properties

        private CreateCardUseCase createCardUseCase = new CreateCardUseCase();

        #endregion

        #region Methods

        [HttpPost]
        [JwtAuthentication]
        public CreationDetails Index()
        {
            CreationDetails details;
            var rParams = HttpContext.Current.Request.Form;
            decimal balance = Convert.ToDecimal(rParams.Get("balance") == "" ? "0" : rParams.Get("balance"));

            try
            {

                details = createCardUseCase.execute(balance);

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