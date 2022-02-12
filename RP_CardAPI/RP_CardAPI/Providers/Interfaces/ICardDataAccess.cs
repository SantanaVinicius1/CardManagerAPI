using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP_CardAPI.Models;

namespace RP_CardAPI.Providers.Interfaces
{
    public interface ICardDataAccess
    {

        int AddCardToDatabase(Card card);

        CardInfo GetCardBalance(int cardID);

        void UpdateCardBalance(int cardID, decimal paymentValue);


    }
}
