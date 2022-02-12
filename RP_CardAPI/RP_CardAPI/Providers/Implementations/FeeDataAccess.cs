using RP_CardAPI.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Providers.Implementations
{
    public class FeeDataAccess : IFeeDataAccess
    {
        public decimal GetCurrentFeeValue()
        {
            try
            {
                using (var db = new CardManagerEntities1())
                {

                    var query = (from b in db.Fees
                                 select b.FeeValue).First();

                    return query.Value;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateFeeValue(decimal newFee)
        {
            try
            {
                var db = new CardManagerEntities1();

                var fee = db.Fees.Where(x => x.ID == 1).FirstOrDefault();

                fee.FeeValue = newFee;

                db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}