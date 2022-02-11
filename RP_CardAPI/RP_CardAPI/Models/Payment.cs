using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class Payment
    {
        public string cardNumber;
        public decimal purchaseValue;

        public Payment() { }
        public Payment(string cNumber, decimal pValue)
        {
            cardNumber = cNumber;
            purchaseValue = pValue;
        }
    }
}