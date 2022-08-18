using EmployessAPI.Models;
using System.Collections.Generic;

namespace EmployessAPI.Data.Interfaces
{
    public interface IJobTitle
    {
        IEnumerable<Job> GetAllJobTitles();
        Job GetJobTitleById(int jobId);
        void CreateJobTitle(Job jobTitle);
        void UpdateJobTitle(Job jobTitle);
        void DeleteJobTitle(int jobId);
    }
}
