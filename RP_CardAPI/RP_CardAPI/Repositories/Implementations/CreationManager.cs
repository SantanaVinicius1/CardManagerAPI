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

        public CreationDetails CreateCard(OwnerInfo info)
        {
            Card card = GenerateCard(info.Name, info.Balance);
            CreationDetails details = ValidateData(card);

            if (details.Success)
            {
                _cardDataAccess.AddCardToDatabase(card);

            }

            return details; 
        }

        private CreationDetails ValidateData(Card card)
        {
            CreationDetails details = new CreationDetails(true, $" Card created successfully \n Card Number: {card.Number} \n Card Security Code: {card.SecurityCode} \n Card Expiration Date: {card.ExpirationDate.ToShortDateString()} \n Balance: {card.Balance}");

            if (string.IsNullOrEmpty(card.OwnerName))
            {
                details.Message = "Invalid owner name";
                details.Success = false;
            }
            if(card.Balance <= 0)
            {
                details.Message = "Balance value must be higher than 0";
                details.Success = false;
            }

            return details;

        }


        private Card GenerateCard(string ownerName, decimal balance)
        {
            string cardNumber = string.Empty;
            string cardSecurityCode;
            DateTime expirationDate = DateTime.Now.AddYears(5);
            Random r = new Random();


            // Generate the card info base on random information
            // Card number generated with 15 random digits
            // CSC generated with three random digits if higher or equals to 100, or 0 + two random digits if lower than 100
            // Expiration date generated based on current time plus 5 years


            //Card number
            for(int i = 0; i < 15; i++)
            {
                int digit = r.Next(0, 9);

                cardNumber += digit.ToString();
            }

            // Security Code
            int securityNumber = r.Next(10, 999);

            if(securityNumber <= 100)
            {
                cardSecurityCode = $"0{securityNumber}";
            }
            else
            {
                cardSecurityCode = securityNumber.ToString();
            }

            return new Card(cardNumber, balance, cardSecurityCode, ownerName, expirationDate);

        }

        #endregion

    }
}