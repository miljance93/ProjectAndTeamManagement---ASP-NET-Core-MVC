using Domain.IdentityAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models;
using ProjectAndTeamManagement.Models.DepartmentLead;
using ProjectAndTeamManagement.Models.ProjectLead;

namespace ProjectAndTeamManagement.Controllers
{
    [Authorize]
    public class TeamLeadController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeamLeadController(IRequestRepository requestRepository, 
            IRequestStatusRepository requestStatusRepository,
            IEmployeeRepository employeeRepository,
            IProjectRepository projectRepository,
            ITeamRepository teamRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _requestRepository = requestRepository;
            _requestStatusRepository = requestStatusRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> AssignmentRequests(string? user)
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

        // GET
        public async Task<ViewResult> CurrentAssignment(string user)
        {
            var teamLead = await _userManager.FindByNameAsync(user);
            var employees = _employeeRepository.GetAll.Where(x => x.TeamId == teamLead?.TeamId);
            var teams = _teamRepository.GetAllTeams.Where(x => x.TeamLeadId == teamLead.Team?.TeamLeadId);

            var list = new AssignmentsList
            {
                Employees = employees,
                TeamLead = teamLead,
                Teams = teams,
            };

            return View(list);
        }

        //GET
        public async Task<IActionResult> ProjectAssignment(string user)
        {
            var teamLead = await _userManager.FindByNameAsync(user);
            var allEmployees = _employeeRepository.GetAll.Where(x => x.Team.TeamLeadId == teamLead.Id);
            var teams = _teamRepository.GetAllTeams;
            var projects = _projectRepository.GetAllProjects;

            var employeesList = new ListsVM
            {
                Employees = allEmployees,
                Teams = teams,
                Projects = projects
            };

            return View(employeesList);
        }

        public IActionResult ApproveRequest(RequestModel requestModel)
        {
            if (requestModel != null)
            {
                var request = _requestRepository.GetAllRequests.FirstOrDefault(x => x.RequestId == requestModel.RequestId);

                request.RequestStatusId = 2;

                var employee = _employeeRepository.GetAll.FirstOrDefault(x => x.Id == requestModel.EmployeeId);

                employee.ProjectId = requestModel.ProjectId;

                _requestRepository.UpdateRequest(request);
                _employeeRepository.UpdateEmployee(employee);

                return RedirectToAction("Index", "Home");
            }


            return Problem();
        }

        //POST
        public IActionResult DeclineRequest(RequestModel requestModel)
        {
            if (requestModel != null)
            {
                var request = _requestRepository.GetAllRequests.FirstOrDefault(x => x.RequestId == requestModel.RequestId);

                request.RequestStatusId = 3;

                _requestRepository.UpdateRequest(request);

                return RedirectToAction("Index", "Home");
            }

            return Problem();
        }

    }
}
