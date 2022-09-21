using Domain;

namespace ProjectAndTeamManagement.Models.DepartmentLead
{
    public class AssignTeam
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
