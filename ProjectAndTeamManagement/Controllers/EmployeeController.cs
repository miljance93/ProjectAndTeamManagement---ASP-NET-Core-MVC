using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models;

namespace ProjectAndTeamManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult CreateEmployee()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeVM model)
        {
            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                TeamId = model.TeamId,
            };

            _employeeRepository.CreateEmployee(employee);

            return RedirectToAction("Index", "Home");
        }
    }
}
