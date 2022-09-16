using ApplicationService.Employees;
using Microsoft.AspNetCore.Mvc;
using Persistence.Core.DTOs;

namespace API.Controllers
{
    public class EmployeeController : BaseAPIController
    {

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employee)
        {
            return HandleResult(await Mediator.Send(new Create.Command(employee)));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return HandleResult(await Mediator.Send(new Search.Query(id))); 
        }
    }
}
