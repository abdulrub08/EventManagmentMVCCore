using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.DOM;
namespace Event.DAL.Repository
{
     public interface ILoginRepository
    {
        Registration ValidateUser(string Username, string Password);
    }
}
