using Domain.IdentityAuth;
using Domain.IdentityAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models;
using ProjectAndTeamManagement.Models.DepartmentLead;

namespace ProjectAndTeamManagement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(IEmployeeRepository employeeRepository, 
            IProjectRepository projectRepository, 
            ITeamRepository teamRepository, 
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _context = context;
            _userManager = userManager;
        }
        // GET
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

        // GET
        public ViewResult AddEmployeeToProject(ApplicationUser user)
        {
            var allProjects = _projectRepository.GetAllProjects;
            var project = new AssignProject
            {
                Projects = allProjects,
                UserId = user.Id
            };

            return View(project);
        }

        // GET
        public ViewResult AssignEmployeeToTeam(ApplicationUser user)
        {
            var teams = _teamRepository.GetAllTeams.Where(x => x.TeamId != 1);
            var team = new AssignTeam
            {
                Teams = teams,
                UserId = user.Id
            };

            return View(team);
        }

        public async Task<IActionResult> RemoveEmployeeFromProject(ApplicationUser user)
        {
            var employee = await _userManager.FindByIdAsync(user.Id);

            if (employee != null)
            {
                employee.ProjectId = null;

                await _userManager.UpdateAsync(employee);
                return RedirectToAction("ProjectAssignment", "DepartmentLead");
            }

            return Problem();            
        }

        public async Task<IActionResult> RemoveEmployeeFromTeam(ApplicationUser user)
        {
            var employee = await _userManager.FindByIdAsync(user.Id);

            if (employee != null)
            {
                employee.TeamId = 1;

                await _userManager.UpdateAsync(employee);
                return RedirectToAction("TeamManagement", "DepartmentLead");
            }

            return Problem();
        }


        // POST
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeVM model)
        {
            if (!ModelState.IsValid)
            {
                return Problem();
            }

            var employee = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                TeamId = model.TeamId,
                RoleId = model.RoleId,
            };

            _employeeRepository.CreateEmployee(employee);

            return RedirectToAction("Index", "Home");
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> AssignToProject(AssignProject project)
        {
            var employee = await _userManager.FindByIdAsync(project.UserId);

            if (employee == null) 
                return Problem();

            employee.ProjectId = project.ProjectId;
            await _userManager.UpdateAsync(employee);

            return RedirectToAction("CurrentAssignments", "DepartmentLead");
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> AssignToTeam(AssignTeam team)
        {
            var employee = await _userManager.FindByIdAsync(team.UserId);

            if (employee == null)
            {
                return Problem();   
            }

            employee.TeamId = team.TeamId;
            await _userManager.UpdateAsync(employee);

            return RedirectToAction("TeamManagement", "DepartmentLead");
        }
    }
}
