using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class PaymentDetails
    {
        public bool Success { get; set; }
        public string Message { get; set; }


        public PaymentDetails() { }

        public PaymentDetails(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}