using RP_CardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_CardAPI.Repositories.Interfaces
{
    public interface IAuthenticationManager
    {

        /// <summary>
        /// Return the JWT of a authenticated user
        /// </summary>
        string GetUserToken(User user);

    }
}
