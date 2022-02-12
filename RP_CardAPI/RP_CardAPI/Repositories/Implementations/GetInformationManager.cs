using RP_CardAPI.Models;
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

        public CardInfo getBalance(int cardID)
        {
            try
            {
                return _cardDataAccess.GetCardBalance(cardID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}