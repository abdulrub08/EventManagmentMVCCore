using Dapper;
using Event.DAL.Repository;
using Event.DOM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Event.DAL.Repositories
{
    public class LoginRepository : BaseRepository,ILoginRepository
    {
        public LoginRepository(IConfiguration configuration) : base(configuration)
        { }
        public Registration ValidateUser(string Username, string Password)
        {
            var query = @"EXEC " + DBConstant.ValidateUser + " @Username,@Password";
            using (var connection = CreateConnection())
            {
                Registration registration = connection.QuerySingle<Registration>(query, new { Username, Password });
                return registration;
            }
        }
    }
}
