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
                                 select b.FeeValue);

                    //if a previous fee value isn't set, then set it as 1;
                    if (!query.Any())
                    {
                        return 1;
                    }

                    return query.First().Value;
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