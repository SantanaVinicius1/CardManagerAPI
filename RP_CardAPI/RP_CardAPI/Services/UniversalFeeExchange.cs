using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentFeeModule.Services
{
    public sealed class UniversalFeeExchange
    {

        private UniversalFeeExchange() { }

        private static UniversalFeeExchange _instance;

        public static UniversalFeeExchange GetInstance()
        {
            if(_instance == null)
            {
                _instance = new UniversalFeeExchange();
            }

            return _instance;
        }

        public static void CalculateFee(decimal lastFee)
        {
            Random r = new Random();

            //Calculate the new factor
            decimal factor = new decimal(r.NextDouble() * 2);

            //set newFee on the DB 
            decimal newFee = lastFee * factor; 

        }

    }
}
