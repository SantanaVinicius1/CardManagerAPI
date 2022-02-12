using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class Card
    {
        #region Properties

        public readonly int ID;
        public readonly string Number;
        public readonly decimal Balance;


        #endregion

        #region Constructor

        public Card(int id, string cNumber, decimal cBalance)
        {
            ID = id;
            Number = cNumber;
            Balance = cBalance;
        }

        public Card(string cNumber, decimal cBalance)
        {
            Number = cNumber;
            Balance = cBalance;
        }

        #endregion

    }
}