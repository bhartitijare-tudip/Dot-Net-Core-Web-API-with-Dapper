using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebAPIWithDapper.Repository;
using DotNetCoreWebAPIWithDapper.Models;

namespace DotNetCoreWebAPIWithDapper.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeRepository.GetAllEmployee();
        }

        // GET api/Employee/1
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeRepository.GetEmployeeByID(id);
        }

        // POST api/Employee
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
                employeeRepository.AddEmployee(employee);
        }

        // PUT api/Employee/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee employee)
        {
            employee.Id = id;
            if (ModelState.IsValid)
                employeeRepository.UpdateEmployee(employee);
        }

        // DELETE api/Employee/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeRepository.DeleteEmployee(id);
        }
    }
}