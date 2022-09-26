using Domain;
using Domain.IdentityAuth;

namespace ProjectAndTeamManagement.Models
{
    public class ListsVM
    {
        public IEnumerable<ApplicationUser> Employees { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<ProjectStatus> ProjectStatuses { get; set; }
    }
}
