using System;
using System.Collections.Generic;
using System.Text;

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

        public static decimal CalculateFee()
        {

            



            return 0;
        }

    }
}
