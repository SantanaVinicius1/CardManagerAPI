using RP_CardAPI.Models;
using RP_CardAPI.UsesCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RP_CardAPI.Controllers
{
    public class AuthenticationController : ApiController
    {


        private AuthenticationUseCase authenticationUseCase = new AuthenticationUseCase();

        [HttpPost]
        [AllowAnonymous]
        public string Index(string username, string password)
        {
            User user = new User(username, password);

            try
            {
                return authenticationUseCase.execute(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


    }
}
