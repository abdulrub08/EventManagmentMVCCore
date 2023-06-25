using Dapper;
using Event.DAL.Repositories;
using Event.DAL.Repository;
using Event.DOM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL.Repositoriesdd
{
    public class FoodRepositry : BaseRepository,IFoodRepository
    {
        IConfiguration _configuration;
        public FoodRepositry(IConfiguration configuration):base(configuration) 
        { 
        
        }
        public List<Food> ShowFood()
        {
            using (var connection = CreateConnection())
            {
                var sql = "select * from Food";
                List<Food> foods = connection.Query<Food>(sql).ToList();
                return foods;
            }
        }
    }
}
