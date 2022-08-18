using Dapper;
using EmployessAPI.Data.Interfaces;
using EmployessAPI.Models;
using System.Collections.Generic;
using System.Data;

namespace EmployessAPI.Data.Implementions
{
    public class EmployeeRepo : BaseRepo, IEmployeeRepo
    {
        public EmployeeRepo(IDbConnection connection) : base(connection)
        {
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            var query = @"SELECT * FROM public.""Employees""";

            return _connection.Query<Employee>(query);
        }

        public Employee GetEmployeeById(int id)
        {
            var query = @"
                    SELECT * 
                    FROM ""Employees""
                    WHERE ""Id"" = @Id";

            var employee = _connection.QueryFirstOrDefault<Employee>(query,  new { id });
            return employee;
        }
        public bool CreateEmployee(Employee employee)
        {
            var query = @"
                INSERT INTO ""Employees""(
                ""FirstName"", ""LastName"", ""FatherName"", ""DateOfBirth"")
	            VALUES(@FirstName, @LastName, @FatherName, @DateOfBirth);";

            return _connection.Execute(query, employee) > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            var query = @"
                UPDATE ""Employees""
                SET ""FirstName"" = @FirstName,
                ""LastName"" = @LastName,
                ""FatherName"" = @FatherName,
                ""DateOfBirth"" = @DateOfBirth
                WHERE ""Id"" = @Id;
                ";

            return _connection.Execute(query, employee) > 0;
        }
        public void DeleteEmployee(int id)
        {
            var query = @"
                    DELETE FROM ""Employees""
                    WHERE ""Id"" = @Id";

            _connection.Execute(query, new { id });
        }
    }
}
