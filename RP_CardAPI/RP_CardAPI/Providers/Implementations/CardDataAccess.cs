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
                var db = new CardManagerEntities1();

                db.Cards.Add(new Cards { cardNumber = card.Number, balance = card.Balance, expirationDate = card.ExpirationDate, OwnerName = card.OwnerName, securityCode = card.SecurityCode });

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void UpdateCardBalance(string cardNumber, decimal paymentValue)
        {
            try
            {
                var db = new CardManagerEntities1();

                var card = db.Cards.Where(x => x.cardNumber == cardNumber).FirstOrDefault();

                card.balance = card.balance - paymentValue;

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

            try
            {
                // check balance 
                using (var db = new CardManagerEntities1())
                {

                    var query = (from b in db.Cards
                                 where b.cardNumber == cardNumber
                                 select b.balance).First();

                    balance = query.Value;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return balance;
        }

        public bool CheckSecurityCode(string cardNumber, string cardSecurityCode)
        {

            bool returnObj = false;

            try
            {
                using (var db = new CardManagerEntities1())
                {

                    var query = (from b in db.Cards
                                 where b.cardNumber == cardNumber
                                 select b.securityCode).First();


                    if(cardSecurityCode == query)
                    {
                        returnObj = true;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex ;
            }

            return returnObj;

        }
    }
}