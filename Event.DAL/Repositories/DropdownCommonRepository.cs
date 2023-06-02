using Dapper;
using Event.DAL.Repository;
using Event.DOM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repositories
{
    public class DropdownCommonRepository : BaseRepository, IDropdownCommonRepository
    {
        public DropdownCommonRepository(IConfiguration configuration) : base(configuration) { }
        IEnumerable<Country> IDropdownCommonRepository.GetCountry()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var sql = "select * from Country";
                    var countries = connection.Query<Country>(sql);
                    return countries;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        IEnumerable<State> IDropdownCommonRepository.GetStatebyID(int ID)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var sql = "select * from States where CountryID="+ID;
                    var states = connection.Query<State>(sql);
                    return states;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        IEnumerable<City> IDropdownCommonRepository.GetCitybyID(int ID)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var sql = "select * from City where StateID=" + ID;
                    var city = connection.Query<City>(sql);
                    return city;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
