using Dapper;
using EmployessAPI.Data.Interfaces;
using System.Data;

namespace EmployessAPI.Data.Implementions
{
    public class EmployeeJobRepo : BaseRepo, IEmployeeJobRepo
    {
        public EmployeeJobRepo(IDbConnection connection) : base(connection)
        {
        }
        public bool AddEmployeeToJob(int employeeId, int jobId)
        {
            var query = @"
                INSERT INTO ""EmployeesJobTitle""(
                ""EmployeeId"", ""JobTitleId"")
	            VALUES(@EmployeeId, @JobId); ";

            return _connection.Execute(query, new { employeeId, jobId }) > 0;
        }

        public void DeleteEmployeeJobByEmploeeId(int employeeId)
        {
            string query = @"
                    DELETE FROM ""EmployeesJobTitle""
                    WHERE ""EmployeeId"" = @employeeId";

            _connection.Execute(query, new { employeeId });
        }
    }
}
