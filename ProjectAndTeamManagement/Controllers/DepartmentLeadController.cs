using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repo.Interfaces;
using ProjectAndTeamManagement.Models;
using ProjectAndTeamManagement.Models.DepartmentLead;

namespace ProjectAndTeamManagement.Controllers
{
    public class DepartmentLeadController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IProjectStatusRepository _projectStatusRepository;

        public DepartmentLeadController(IEmployeeRepository employeeRepository, 
            IProjectRepository projectRepository, 
            ITeamRepository teamRepository,
            IProjectStatusRepository projectStatusRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _teamRepository = teamRepository;
            _projectStatusRepository = projectStatusRepository;
        }
        //GET
        public IActionResult ProjectManagement()
        {
            var projects = _projectRepository.GetAllProjects;
            var teams = _teamRepository.GetAllTeams;
            var employees = _employeeRepository.GetAll;
            var projectStatuses = _projectStatusRepository.GetAllProjectStatuses;

            var project = new EmployeesListVM
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

            var employeesList = new EmployeesListVM
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
            var employees = _employeeRepository.GetAll;
            var projectStatuses = _projectStatusRepository.GetAllProjectStatuses;
            var employeesList = new CreateNewProject
            {
                Employees = employees,
                ProjectStatuses = projectStatuses
            };

            return View(employeesList);
        }

        //GET
        public IActionResult TeamManagement()
        {
            var teams = _teamRepository.GetAllTeams;
            var employees = _employeeRepository.GetAll;

            var employeeVM = new EmployeesListVM
            {
                Teams = teams,
                Employees = employees
            };

            return View(employeeVM);
        }

        //GET
        public IActionResult CreateNewTeam()
        {
            return View();
        }

        //GET
        public IActionResult CurrentAssignments()
        {
            var projects = _projectRepository.GetAllProjects;
            var employees = _employeeRepository.GetAll;
            var teams = _teamRepository.GetAllTeams;

            var currentAssignments = new EmployeesListVM
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
            return View();
        }


        //POST
        [HttpPost]
        public IActionResult CreateNewProject(CreateNewProject model)
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

                _projectRepository.CreateNewProject(project);

                return RedirectToAction("ProjectManagement");
            }

            return Problem("Project not created!");
        }

        //POST
        [HttpPost]
        public IActionResult CreateNewTeam(CreateNewTeam model)
        {
            if (ModelState.IsValid)
            {
                var team = new Team
                {
                    TeamName = model.Name
                };

                _teamRepository.CreateNewTeam(team);

                return RedirectToAction("CurrentAssignments");
            }

            return Problem("Team not created!");
        }
    }
}
