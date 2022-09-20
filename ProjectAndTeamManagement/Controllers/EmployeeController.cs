using Domain;
using Domain.IdentityAuth;
using Domain.IdentityAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models;

namespace ProjectAndTeamManagement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbContext _context;

        public EmployeeController(IEmployeeRepository employeeRepository, ApplicationDbContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }

        public ViewResult CreateEmployee()
        {
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(_context);
            List<IdentityRole> roles = roleStore.Roles.ToList();

            var employee = new Register
            {
                Roles = roles,
            };

            return View(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeVM model)
        {
            var employee = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                TeamId = model.TeamId,
                //RoleId = model.RoleId
            };

            _employeeRepository.CreateEmployee(employee);

            return RedirectToAction("Index", "Home");
        }
    }
}
