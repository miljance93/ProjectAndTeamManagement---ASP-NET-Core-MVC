using Domain;
using Domain.IdentityAuth;

namespace ProjectAndTeamManagement.Models.TeamLead
{
    public class EmployeeRequest
    {
        public int EmployeeId { get; set; }
        public IEnumerable<ApplicationUser> Employees { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
