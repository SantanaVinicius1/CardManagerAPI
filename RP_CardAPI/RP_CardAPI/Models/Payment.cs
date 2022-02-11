using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class Payment
    {
        public string cardNumber;
        public string cardSecurityCode;
        public decimal purchaseValue;
        

        public Payment() { }
        public Payment(string cNumber, string cSecurityCode, decimal pValue)
        {
            cardNumber = cNumber;
            purchaseValue = pValue;
            cardSecurityCode = cSecurityCode;
        }
    }
}