using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL
{
    internal class DBConstant
    {
        #region Login
        public const string ValidateUser = "PROC_ValidateUser";
        public const string RegisterUser = "PROC_RegisterUser";
        #endregion
        #region Venue
        public const string AddVenue = "PROC_AddVenue";
        #endregion
    }
}
