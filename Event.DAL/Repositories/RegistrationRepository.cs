using Dapper;
using Event.DAL.Repository;
using Event.DOM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repositories
{
    public class RegistrationRepository : BaseRepository,IRegistrationRepository
    {       
        public RegistrationRepository(IConfiguration configuration) : base(configuration) { }
        public string NEW_Admin(Registration registration)
        {
            try
            {
                int rows_affected = CreateUser(registration);
                return rows_affected > 0 ? "Success" : "Fail";
            }
            catch (Exception)
            {
                return "Fail";
                throw;
            }
        }
        public string NEW_Customer(Registration registration)
        {
            try
            {
                int rows_affected = CreateUser(registration);
                return rows_affected > 0 ? "Success" : "Fail";
            }
            catch (Exception)
            {
                return "Fail";
                throw;
            }
        }
        private int CreateUser(Registration model)
        {
            int rowAffected = 0;
            #region Commented for Not in Use
            using (var connection = CreateConnection())
            {
                
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Address", model.Address);
                parameters.Add("@City", model.City);
                parameters.Add("@State", model.State);
                parameters.Add("@Country", model.Country);
                parameters.Add("@Mobileno", model.Mobileno);
                parameters.Add("@EmailID", model.EmailID);
                parameters.Add("@Username", model.Username);
                parameters.Add("@Password", model.Password);
                parameters.Add("@ConfirmPassword", model.ConfirmPassword);
                parameters.Add("@Gender", model.Gender);
                parameters.Add("@Birthdate", model.Birthdate);
                parameters.Add("@RoleID", model.RoleID);
                rowAffected = connection.Execute(DBConstant.RegisterUser, parameters, commandType: CommandType.StoredProcedure);
            }
            #endregion            
            return rowAffected;
        }
    }
}
