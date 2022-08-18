using Npgsql;
using System.Data;

namespace EmployessAPI.Data
{
    public class BaseRepo
    {
        protected IDbConnection _connection;

        protected BaseRepo (IDbConnection connection)
        {
            _connection = connection;
        }
    }
}
