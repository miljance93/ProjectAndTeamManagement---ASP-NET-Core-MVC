using Domain;
using Domain.IdentityAuth;

namespace ProjectAndTeamManagement.Models.DepartmentLead
{
    public class AssignProject
    {
        public string UserId { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
