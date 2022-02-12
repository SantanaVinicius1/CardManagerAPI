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
        public int AddCardToDatabase(Card card)
        {

            Cards insertObj = new Cards { cardNumber = card.Number, Balance = card.Balance };

            try
            {
                var db = new CardManagerEntities1();

                db.Cards.Add(insertObj);

                db.SaveChanges();

                return insertObj.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void UpdateCardBalance(int cardID, decimal paymentValue)
        {
            try
            {
                var db = new CardManagerEntities1();

                var card = db.Cards.Where(x => x.ID == cardID).FirstOrDefault();

                card.Balance = card.Balance - paymentValue;

                db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CardInfo GetCardBalance(int cardID)
        {

            CardInfo info = new CardInfo();

            try
            {
                // check balance 
                using (var db = new CardManagerEntities1())
                {

                    var query = (from b in db.Cards
                                 where b.ID == cardID
                                 select b).First();

                    info.cardNumber = query.cardNumber;
                    info.CardBalance = (decimal) query.Balance;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return info;
        }

      
    }
}