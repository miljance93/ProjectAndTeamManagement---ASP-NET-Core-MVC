using Domain.IdentityAuth;

namespace ProjectAndTeamManagement.Models.DepartmentLead
{
    public class CreateNewTeam
    {
        public string Name { get; set; }
        public IEnumerable<ApplicationUser> Employees { get; set; }
    }
}
