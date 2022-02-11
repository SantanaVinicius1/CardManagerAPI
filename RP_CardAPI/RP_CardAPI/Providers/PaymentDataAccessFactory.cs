using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Providers.Implementations;
using RP_CardAPI.Providers.Interfaces;

namespace RP_CardAPI.Providers
{
    public class PaymentDataAccessFactory
    {

        public static IPaymentDataAccess GetPaymentDataAcessObj()
        {
            return new PaymentDataAccess();
        }
    }
}