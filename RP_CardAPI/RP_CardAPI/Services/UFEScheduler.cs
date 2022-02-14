using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using RP_CardAPI.Providers.Interfaces;
using RP_CardAPI.Providers;

namespace RP_CardAPI.Services
{
    public static class UFEScheduler
    {

        /// <summary>
        /// Set the scheduler to update the fees ever hour
        /// </summary>
        public static void StartScheduler()
        {
            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(UpdateFee);
            t.Interval = 60 * 60 * 1000 ;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }

        private static void UpdateFee(object sender, System.Timers.ElapsedEventArgs e)
        {
            IFeeDataAccess _feeDataAccess = FeeDataAccessFactory.getCardFeeAccessObj();

            decimal currentFee = _feeDataAccess.GetCurrentFeeValue();

            decimal newFee = UniversalFeeExchange.CalculateFee(currentFee);

            _feeDataAccess.UpdateFeeValue(newFee);

        }

    }
}