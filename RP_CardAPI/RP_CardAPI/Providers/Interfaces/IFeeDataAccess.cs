using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_CardAPI.Providers.Interfaces
{
    public interface IFeeDataAccess
    {
        decimal GetCurrentFeeValue();

        void UpdateFeeValue(decimal newFee);
    }
}
