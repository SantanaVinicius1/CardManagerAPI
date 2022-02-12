using RP_CardAPI.Models;
using RP_CardAPI.UsesCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RP_CardAPI.Controllers
{
    public class AuthenticationController : ApiController
    {


        private AuthenticationUseCase authenticationUseCase = new AuthenticationUseCase();

        [HttpPost]
        [AllowAnonymous]
        public AuthInfo Index()
        {
            var rParams = HttpContext.Current.Request.Form;
            User user = new User();
            string token;

            try
            {
                if (string.IsNullOrEmpty(rParams.Get("username")) || string.IsNullOrEmpty(rParams.Get("password")))
                {
                    return new AuthInfo(false, "", "Invalid username or password");
                    
                }

                user.Username = rParams.Get("username");
                user.Password = rParams.Get("password");

                token = authenticationUseCase.execute(user);

                if (string.IsNullOrEmpty(token))
                {
                    return new AuthInfo(false, "", "Wrong username or password");
                }

                return new AuthInfo(true, token, "User authenticated");


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


    }
}
