using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class CreationDetails
    {
        public bool Success;
        public string Message;


        public CreationDetails() { }

        public CreationDetails(bool success, string details)
        {
            Success = success;
            Message = details;
        }
    }
}