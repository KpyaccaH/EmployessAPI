namespace EmployessAPI.Data.Interfaces
{
    public interface IEmployeeJobRepo
    {
        public void DeleteEmployeeJobByEmploeeId(int employeeId);

        public bool AddEmployeeToJob(int employeeId, int jobId);
    }
}
