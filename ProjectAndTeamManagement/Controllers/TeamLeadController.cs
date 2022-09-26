using Domain.IdentityAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models.DepartmentLead;

namespace ProjectAndTeamManagement.Controllers
{
    [Authorize]
    public class TeamLeadController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeamLeadController(IRequestRepository requestRepository, 
            IRequestStatusRepository requestStatusRepository,
            IEmployeeRepository employeeRepository,
            IProjectRepository projectRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _requestRepository = requestRepository;
            _requestStatusRepository = requestStatusRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> AssignmentRequests(string user)
        {
            var teamLead = await _userManager.FindByNameAsync(user);
            var requests = _requestRepository.GetAllRequests.Where(x => x.TeamLeadId == teamLead.Id);
            var statuses = _requestStatusRepository.GetAllRequestStatuses;
            var employees = _employeeRepository.GetAll;
            var projects = _projectRepository.GetAllProjects;

            var request = new RequestModel
            {
                Requests = requests,
                RequestStatuses = statuses,
                Employees = employees,
                Projects = projects
            };

            return View(request);
        }

        public IActionResult CurrentAssignment()
        {
            return View();
        }

        public IActionResult ProjectAssignment()
        {
            return View();
        }

    }
}
