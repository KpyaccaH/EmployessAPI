using System;

namespace EmployessAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }    
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
