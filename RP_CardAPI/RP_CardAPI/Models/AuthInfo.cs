using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class AuthInfo
    {
        public bool Authenticated;
        public string Token;
        public string Message;


        public AuthInfo() { }

        public AuthInfo(bool authenticated, string token, string message)
        {

            Authenticated = authenticated;
            Token = token;
            Message = message;
        }
    }
}