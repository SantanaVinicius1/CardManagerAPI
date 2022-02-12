using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RP_CardAPI.Models;

namespace RP_CardAPI.Repositories
{
    public interface ICreationManager
    {
        CreationDetails CreateCard(decimal cardBalance);
        
    }
}