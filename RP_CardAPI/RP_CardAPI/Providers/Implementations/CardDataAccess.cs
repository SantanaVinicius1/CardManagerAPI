using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Models;
using RP_CardAPI.Providers.Interfaces;

namespace RP_CardAPI.Providers.Implementations
{
    public class CardDataAccess : ICardDataAccess
    {
        public void AddCardToDatabase(Card card)
        {
            try
            {
                var db = new CardManagerEntities();

                db.Cards.Add(new Cards { cardNumber = card.Number, balance = card.Balance, expirationDate = card.ExpirationDate, OwnerName = card.OwnerName, securityCode = card.SecurityCode });

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public decimal GetCardBalance(string cardNumber)
        {

            decimal balance = 0;
            // check balance 
            using (var db = new CardManagerEntities())
            {

                var query = (from b in db.Cards
                             where b.cardNumber == cardNumber
                             select b.balance).First();

                balance = query.Value;
            }

            return balance;
        }

    }
}