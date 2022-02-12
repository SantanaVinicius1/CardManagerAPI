using RP_CardAPI.Models;
using RP_CardAPI.Providers;
using RP_CardAPI.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Repositories.Implementations
{
    public class CreationManager : ICreationManager
    {
        #region Properties

        ICardDataAccess _cardDataAccess;

        #endregion

        #region Methods

        public CreationManager()
        {
            _cardDataAccess = CardDataAccessFactory.getCardDataAccessObj();
        }

        public CreationDetails CreateCard(decimal balance)
        {
            Card card = GenerateCardNumber(balance);
            CreationDetails details = ValidateData(balance);
            int cardID;

            if (details.Success)
            {
                cardID = _cardDataAccess.AddCardToDatabase(card);

                details.Message = $"Card successfully created. Your card ID is {cardID}, you may use it to make payments";
            }

            return details; 
        }

        private CreationDetails ValidateData(decimal balance)
        {
            CreationDetails details = new CreationDetails(true);

            if(balance <= 0)
            {
                details.Message = "Balance value must be higher than 0";
                details.Success = false;
            }

            return details;

        }


        private Card GenerateCardNumber(decimal balance)
        {
            string cardNumber = string.Empty;
            Random r = new Random();


            // Generate the card info based on random information
            // Card number generated with 15 random digits
            for(int i = 0; i < 15; i++)
            {
                int digit = r.Next(0, 9);

                cardNumber += digit.ToString();
            }


            return new Card(cardNumber, balance);

        }

        #endregion

    }
}