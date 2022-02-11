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

        void AddCardToDatabase(Card card);

        decimal GetCardBalance(string cardNumber);

    }
}
