using Event.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repositories
{
    public interface IAccount
    {
        public bool IsUserNameAvailable();
        public bool IsUserValid();
        public Registration GetLogedinUserByID(int _recId);
        public Registration GetLogedinUserByUserIDPassword(string userID, string password);
    }
}
