using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class Card
    {
        #region Properties

        public readonly string Number;
        public readonly decimal Balance;
        public readonly string SecurityCode;
        public readonly string OwnerName;
        public readonly DateTime ExpirationDate;


        #endregion

        #region Constructor

        public Card(string cNumber, decimal cBalance, string cSecurityCode, string cOwnerName, DateTime cExpirationDate)
        {
            Number = cNumber;
            Balance = cBalance;
            SecurityCode = cSecurityCode;
            OwnerName = cOwnerName;
            ExpirationDate = cExpirationDate;
        }

        #endregion

    }
}