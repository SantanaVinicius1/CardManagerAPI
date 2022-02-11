using RP_CardAPI.Providers;
using RP_CardAPI.Providers.Interfaces;
using RP_CardAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Repositories.Implementations
{
    public class GetInformationManager : IGetInformationManager
    {
        #region Properties

        ICardDataAccess _cardDataAccess;

        #endregion

        public GetInformationManager()
        {
            _cardDataAccess = CardDataAccessFactory.getCardDataAccessObj();
        }

        public decimal getBalance(string cardNumber)
        {
            try
            {
                return _cardDataAccess.GetCardBalance(cardNumber);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}