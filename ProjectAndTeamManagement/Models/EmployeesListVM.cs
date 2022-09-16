using Domain;

namespace ProjectAndTeamManagement.Models
{
    public class EmployeesListVM
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<ProjectStatus> ProjectStatuses { get; set; }
    }
}
