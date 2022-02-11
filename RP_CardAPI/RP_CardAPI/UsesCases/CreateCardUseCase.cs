using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Repositories;
using RP_CardAPI.Repositories.Implementations;
using RP_CardAPI.Models;

namespace RP_CardAPI.UsesCases
{
    public class CreateCardUseCase
    {
        #region Properties

        ICreationManager createCardManager;

        #endregion

        #region Constructor

        public CreateCardUseCase()
        {
            createCardManager = new CreationManager();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Exec the creation of a new card
        /// </summary>
        public CreationDetails execute(OwnerInfo info)
        {
             return this.createCardManager.CreateCard(info);
        }

        #endregion
        

    }
}