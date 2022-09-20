using Domain;
using Microsoft.AspNetCore.Identity;

namespace ProjectAndTeamManagement.Models
{
    public class EmployeeVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string  FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public Project Project { get; set; }
        public int TeamId { get; set; } = 1; //1 je Unassigned
        public Team Team { get; set; }
        public string RoleId { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
