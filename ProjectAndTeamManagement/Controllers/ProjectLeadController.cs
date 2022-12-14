using Application.Models;
using Application.Services.Interfaces;
using Domain;
using Domain.IdentityAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models.ProjectLead;
using ProjectAndTeamManagement.Models.TeamLead;

namespace ProjectAndTeamManagement.Controllers
{
    [Authorize]
    public class ProjectLeadController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly IProjectLeadService projectLeadService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectLeadController(IEmployeeRepository employeeRepository, 
            IRequestRepository requestRepository,
            IProjectRepository projectRepository,
            ITeamRepository teamRepository,
            IRequestStatusRepository requestStatusRepository,
            IProjectLeadService projectLeadService,
            UserManager<ApplicationUser> userManager)
        {
            _employeeRepository = employeeRepository;
            _requestRepository = requestRepository;
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _requestStatusRepository = requestStatusRepository;
            this.projectLeadService = projectLeadService;
            _userManager = userManager;
        }


        // GET
        public async Task<ViewResult> AssignmentRequests(string? user)
        {
            var projectLead = await _userManager.FindByNameAsync(user);
            var requests = _requestRepository.GetAllRequests.Where(x => x.ProjectLeadId == projectLead.Id);
            var employees = _employeeRepository.GetAll;
            var requestStatuses = _requestStatusRepository.GetAllRequestStatuses;
            var projects = _projectRepository.GetAllProjects;

            var assignements = new AssignmentsList
            {
                Requests = requests,
                Employees = employees,
                RequestStatuses = requestStatuses,
                Projects = projects
            };
            return View(assignements);
        }

        // GET
        public async Task<ViewResult> CurrentAssignments(string user)
        {
            var projectLead = await _userManager.FindByNameAsync(user);
            var project = _projectRepository.GetAllProjects.FirstOrDefault(x => x.ProjectLeadId == projectLead.Id);
            var employees = _employeeRepository.GetAll.Where(x => x.ProjectId == project?.ProjectId);

            var list = new AssignmentsList
            {
               Employees = employees,
               Project = project,
               ProjectLead = projectLead,
            };

            return View(list);
        }


        // GET
        public async Task<ViewResult> CreateNewRequest(string user)
        {
            var projectLead = await _userManager.FindByNameAsync(user);
            var projects = _projectRepository.GetAllProjects.Where(x => x.ProjectLeadId == projectLead.Id);
            var employees = _employeeRepository.GetAll.Where(x => x.ProjectId == null);

            var request = new EmployeeRequest
            {
                Projects = projects,
                Employees = employees
            };

            return View(request);
        }


        // POST
        [HttpPost]
        public async Task<IActionResult> CreateNewRequest(EmployeeRequestService request)
        {
            var projectLeadId = await _userManager.FindByNameAsync(User.Identity?.Name);


            projectLeadService.CreateNewRequest(request, projectLeadId);

            //if (ModelState.IsValid)
            //{
            //    var requestForEmployee = new Request
            //    { 
            //        EmployeeId = request.EmployeeId,
            //        DepartmentLeadId = request.LeadId,
            //        ProjectLeadId = projectLeadId.Id,
            //        StartDate = request.StartDate,
            //        EndDate = request.EndDate,
            //        ProjectId = request.ProjectId,
            //        RequestStatusId = request.RequestStatusId,
            //        TeamLeadId = request.LeadId
            //    };

            //    _requestRepository.CreateNewRequest(requestForEmployee);

              return RedirectToAction("Index", "Home");
            //}

            //return Problem();
        }
    }
}
