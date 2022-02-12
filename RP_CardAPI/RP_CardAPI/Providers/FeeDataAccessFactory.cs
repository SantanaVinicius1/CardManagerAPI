using RP_CardAPI.Providers.Implementations;
using RP_CardAPI.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Providers
{
    public class FeeDataAccessFactory
    {
        public static IFeeDataAccess getCardFeeAccessObj()
        {
            return new FeeDataAccess();
        }
    }
}