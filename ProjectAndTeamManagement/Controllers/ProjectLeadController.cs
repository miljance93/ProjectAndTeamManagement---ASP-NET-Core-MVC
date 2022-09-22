using Domain.IdentityAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models;

namespace ProjectAndTeamManagement.Controllers
{
    public class ProjectLeadController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectLeadController(IEmployeeRepository employeeRepository, IProjectRepository projectRepository, UserManager<ApplicationUser> userManager)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _userManager = userManager;
        }
        public ViewResult AssignmentRequests()
        {
            return View();
        }

        public async Task<ViewResult> CurrentAssignments(string user)
        {
            var projectLead = await _userManager.FindByNameAsync(user);
            var project = _projectRepository.GetAllProjects.FirstOrDefault(x => x.ProjectLeadId == projectLead.Id);
            var employees = _employeeRepository.GetAll.Where(x => x.ProjectId == project?.ProjectId);

            var list = new ListsVM
            {
               Employees = employees,
            };

            return View(list);
        }
    }
}
