using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RP_CardAPI.UsesCases;
using RP_CardAPI.Models;
using System.Net.Http;
using System.Net;


namespace RP_CardAPI.Controllers
{
    
    public class CreateCardController : ApiController
    {
        #region Properties

        private CreateCardUseCase createCardUseCase = new CreateCardUseCase();

        #endregion

        #region Methods

        [HttpPost]
        public HttpResponseMessage Index(string cardOwnerName, decimal cardBalance)
        {
            OwnerInfo info  = new OwnerInfo(cardOwnerName, cardBalance);
            CreationDetails details;

            try
            {
                details = createCardUseCase.execute(info);

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