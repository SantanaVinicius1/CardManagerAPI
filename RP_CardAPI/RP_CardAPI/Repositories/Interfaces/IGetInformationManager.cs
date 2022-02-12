using RP_CardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_CardAPI.Repositories.Interfaces
{
    interface IGetInformationManager
    {
        CardInfo getBalance(int cardID);
    }
}
