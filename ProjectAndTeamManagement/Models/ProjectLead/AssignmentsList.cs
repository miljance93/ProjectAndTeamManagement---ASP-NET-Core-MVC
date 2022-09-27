using Domain;
using Domain.IdentityAuth;

namespace ProjectAndTeamManagement.Models.ProjectLead
{
    public class AssignmentsList
    {
        public ApplicationUser TeamLead { get; set; }
        public ApplicationUser ProjectLead { get; set; }
        public Project Project { get; set; }
        public IEnumerable<ApplicationUser> Employees { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<RequestStatus> RequestStatuses { get; set; }

    }
}
