using Microsoft.AspNetCore.Authorization;
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

        public TeamLeadController(IRequestRepository requestRepository, 
            IRequestStatusRepository requestStatusRepository,
            IEmployeeRepository employeeRepository,
            IProjectRepository projectRepository
            )
        {
            _requestRepository = requestRepository;
            _requestStatusRepository = requestStatusRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
        }
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
