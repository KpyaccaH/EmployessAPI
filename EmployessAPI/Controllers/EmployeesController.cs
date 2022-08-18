using EmployessAPI.Data.Implementions;
using EmployessAPI.Data.Interfaces;
using EmployessAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IEmployeeJobRepo _employeeJobRepo;

        public EmployeesController(IEmployeeRepo employeeRepo, IEmployeeJobRepo employeeJobRepo)
        {
            _employeeRepo = employeeRepo;
            _employeeJobRepo = employeeJobRepo;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeeItems = _employeeRepo.GetAllEmployees();

            if (employeeItems == null || !employeeItems.Any())
            {
                return NotFound();
            }

            return Ok(employeeItems);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var employee = _employeeRepo.GetEmployeeById(id);

            if(employee == null) 
            { 
                return NotFound(); 
            }
            return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult CreateEmployee([FromBody] Employee employee)
        {
            var result = _employeeRepo.CreateEmployee(employee);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("AddToJob")]
        public ActionResult AddToJob(int employeeId, int jobId)
        {
            var result = _employeeJobRepo.AddEmployeeToJob(employeeId, jobId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var employeeToUpdate = _employeeRepo.GetEmployeeById(id);
            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            employee.Id = id;
            _employeeRepo.UpdateEmployee(employee);
            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employeeToDelete = _employeeRepo.GetEmployeeById(id);
            if (employeeToDelete == null)
            {
                return NoContent();
            }

            _employeeJobRepo.DeleteEmployeeJobByEmploeeId(id);
            _employeeRepo.DeleteEmployee(id);
            return Ok();
        }
    }
}
