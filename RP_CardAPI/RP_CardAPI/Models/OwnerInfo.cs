using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_CardAPI.Models
{
    public class OwnerInfo
    {

        public string Name;
        public decimal Balance;


        public OwnerInfo(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}