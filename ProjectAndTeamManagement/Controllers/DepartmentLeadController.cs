using Domain;
using Domain.IdentityAuth;
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
    public class DepartmentLeadController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IProjectStatusRepository _projectStatusRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DepartmentLeadController(IEmployeeRepository employeeRepository,
            IProjectRepository projectRepository,
            ITeamRepository teamRepository,
            IProjectStatusRepository projectStatusRepository,
            IRequestRepository requestRepository,
            IRequestStatusRepository requestStatusRepository,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _projectStatusRepository = projectStatusRepository;
            _requestRepository = requestRepository;
            _requestStatusRepository = requestStatusRepository;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //GET
        public IActionResult ProjectManagement()
        {
            var projects = _projectRepository.GetAllProjects;
            var teams = _teamRepository.GetAllTeams;
            var employees = _employeeRepository.GetAll;
            var projectStatuses = _projectStatusRepository.GetAllProjectStatuses;

            var project = new ListsVM
            {
                Projects = projects,
                Employees = employees,
                Teams = teams,
                ProjectStatuses = projectStatuses
            };
            return View(project);
        }
        //GET
        public IActionResult ProjectAssignment()
        {
            var allEmployees = _employeeRepository.GetAll;
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
        //GET
        public IActionResult CreateNewProject()
        {
            var employees = _employeeRepository.GetAll.Where(x => x.RoleId == "5");
            var projectStatuses = _projectStatusRepository.GetAllProjectStatuses;

            RoleStore<IdentityRole> roleStore = new(_context);
            var roles = roleStore.Roles.ToList();

            var employeesList = new CreateNewProject
            {
                Employees = employees,
                ProjectStatuses = projectStatuses,
                Roles = roles
            };

            return View(employeesList);
        }

        //GET
        public IActionResult TeamManagement()
        {
            var teams = _teamRepository.GetAllTeams;
            var employees = _employeeRepository.GetAll;

            var employeeVM = new ListsVM
            {
                Teams = teams,
                Employees = employees,

            };

            return View(employeeVM);
        }

        //GET
        public IActionResult CreateNewTeam()
        {
            var employees = _employeeRepository.GetAll.Where(x => x.RoleId == "5");

            var team = new CreateNewTeam
            {
                Employees = employees
            };

            return View(team);
        }

        //GET
        public IActionResult CurrentAssignments()
        {
            var projects = _projectRepository.GetAllProjects;
            var employees = _employeeRepository.GetAll;
            var teams = _teamRepository.GetAllTeams;

            var currentAssignments = new ListsVM
            {
                Projects = projects,
                Employees = employees,
                Teams = teams
            };

            return View(currentAssignments);
        }

        //GET 
        public IActionResult AssignmentRequests()
        {
            var requests = _requestRepository.GetAllRequests;
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


        //POST
        [HttpPost]
        public async Task<IActionResult> CreateNewProject(CreateNewProject model)
        {
            if (ModelState.IsValid)
            {
                var project = new Project
                {
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Path = model.Path,
                    ProjectLeadId = model.EmployeeId,
                    ProjectStatusId = model.ProjectStatusId,
                };

                var role = await _roleManager.FindByIdAsync("4");

                await UpdateUser(model.EmployeeId, role);

                _projectRepository.CreateNewProject(project);

                return RedirectToAction("ProjectManagement");
            }

            return Problem("Project not created!");
        }


        //POST
        [HttpPost]
        public async Task<IActionResult> CreateNewTeam(CreateNewTeam model)
        {
            if (ModelState.IsValid)
            {
                var team = new Team
                {
                    TeamName = model.Name,
                    TeamLeadId = model.EmployeeId
                };
                var role = await _roleManager.FindByIdAsync("3");

                await UpdateUser(model.EmployeeId, role);

                _teamRepository.CreateNewTeam(team);

                return RedirectToAction("CurrentAssignments");
            }

            return Problem("Team not created!");
        }

        private async Task<bool> UpdateUser(string employeeId, IdentityRole role)
        {
            var user = _employeeRepository.GetAll.FirstOrDefault(x => x.Id == employeeId);

            await _userManager.AddToRoleAsync(user, role.Name);

            user.RoleId = role.Id;

            await _userManager.UpdateAsync(user);

            return _employeeRepository.UpdateEmployee(user);
        }

        //POST
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

                return RedirectToAction("AssignmentRequests");
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

                return RedirectToAction("AssignmentRequests");
            }

            return Problem();
        }
    }
}
