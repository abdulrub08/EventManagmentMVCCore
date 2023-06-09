using Dapper;
using System.Data;

namespace Event.DAL.Repositories
{
    public interface ICommonRepository : IDisposable
    {
        T Insert<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure);
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure);
        int Delete<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure);
    }
}
