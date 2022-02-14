using RP_CardAPI.Models;
using RP_CardAPI.Repositories.Interfaces;
using RP_CardAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace RP_CardAPI.Repositories.Implementations
{
    public class AuthenticationManager : IAuthenticationManager
    {


        /// <summary>
        /// Return the JWT of a authenticated user
        /// </summary>
        public string GetUserToken(User user)
        {
            if (AuthenticateUser(user))
            {
                return JwtManager.GenerateToken(user.Username);
            }

            return string.Empty;
        }

        /// <summary>
        /// Authenticate user into databse
        /// </summary>
        public bool AuthenticateUser(User user)
        {
            using (var db = new CardManagerEntities1())
            {
                var query = (from b in db.Users
                             where b.Username == user.Username && b.password == user.Password
                             select b);

                if(!query.Any())
                {
                    return false;
                }

                return true; 
            }
        }
    }
}