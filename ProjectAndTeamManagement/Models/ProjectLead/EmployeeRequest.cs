using Domain;
using Domain.IdentityAuth;

namespace ProjectAndTeamManagement.Models.TeamLead
{
    public class EmployeeRequest
    {
        public string DepartmentLeadId { get; set; }
        public string? ProjectLeadId { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<ApplicationUser>? Employees { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<Project>? Projects { get; set; }
        public int RequestStatusId { get; set; } = 1;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
