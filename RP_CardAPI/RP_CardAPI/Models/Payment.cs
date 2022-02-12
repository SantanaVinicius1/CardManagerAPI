using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class Payment
    {
        public int CardID;
        public decimal PaymentValue;

        
        public Payment() { }
        public Payment(int cID, decimal pValue)
        {
            CardID = cID;
            PaymentValue = pValue;

        }
    }
}