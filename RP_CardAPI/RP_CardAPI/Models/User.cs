using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class User
    {
        public string Username;
        public string Password;


        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}