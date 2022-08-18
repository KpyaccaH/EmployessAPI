using EmployessAPI.Models;
using System.Collections.Generic;

namespace EmployessAPI.Data.Interfaces
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
