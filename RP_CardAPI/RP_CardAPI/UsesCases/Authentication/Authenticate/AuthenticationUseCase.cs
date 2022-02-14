using RP_CardAPI.Models;
using RP_CardAPI.Repositories.Implementations;
using RP_CardAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;

namespace RP_CardAPI.UsesCases
{
    public class AuthenticationUseCase
    {
        IAuthenticationManager _authenticationManager;


        public AuthenticationUseCase()
        {
            _authenticationManager = new AuthenticationManager();
        }


        public string execute(User user)
        {
            return _authenticationManager.GetUserToken(user);
        }

    }
}