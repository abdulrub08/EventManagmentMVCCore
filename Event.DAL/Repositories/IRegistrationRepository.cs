using Event.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repository
{
   public interface IRegistrationRepository
    {
        string NEW_Customer(Registration Registration);
        string NEW_Admin(Registration registration);
    }
}
