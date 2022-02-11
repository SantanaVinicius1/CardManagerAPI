using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP_CardAPI.Models;

namespace RP_CardAPI.Repositories.Interfaces
{
    public interface IPaymentManager
    {
        PaymentDetails ValidatePayment(Payment payment);

        void SavePayment(Payment payment);
    }
}
