using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_CardAPI.Repositories.Interfaces
{
    interface IGetInformationManager
    {
        decimal getBalance(string cardNumber);
    }
}
