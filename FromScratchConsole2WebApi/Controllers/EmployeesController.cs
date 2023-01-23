using FromScratchConsole2WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FromScratchConsole2WebApi.Controllers
{
    //[Route("api/[controller]")]//best practice
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [Route("")]
        //returns json for an instance of an EmployeeModel
        //public Employee GetEmployees()
        //{
        //    return new Employee() { Id = 23, Name = "Kalinka" };
        //}

        //returns list/ienumerable
        //public List<Employee> GetEmployees()
        public IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>() {
                new Employee () {Id = 33, Name = "Memedov" },
                new Employee() { Id = 43, Name = "Shevchenko" }
            };
        }

        [Route("{id}")]
        //returns multiple types of data 
        public IActionResult GetEmployees(int id)
        {
            if (id == 0) { return NotFound(); }

            return Ok
            (new List<Employee>()
            {
                new Employee () {Id = 33, Name = "Memedov" },
                new Employee() { Id = 43, Name = "Shevchenko" }
            }
            );
        }
    }
}
