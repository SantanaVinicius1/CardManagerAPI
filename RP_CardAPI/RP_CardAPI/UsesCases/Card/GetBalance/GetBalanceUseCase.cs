using RP_CardAPI.Models;
using RP_CardAPI.Repositories.Implementations;
using RP_CardAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.UsesCases
{
    public class GetBalanceUseCase
    {
        #region Properties

        IGetInformationManager createCardManager;

        #endregion

        #region Constructor

        public GetBalanceUseCase()
        {
            createCardManager = new GetInformationManager();
        }

        #endregion

        #region Methods

        public CardInfo execute(int cardID)
        {
            return createCardManager.getBalance(cardID);
        }

        #endregion
    }
}