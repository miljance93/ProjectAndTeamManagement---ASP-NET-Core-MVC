using Domain;

namespace ProjectAndTeamManagement.Models
{
    public class EmployeeVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string  FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public Project Project { get; set; }
        public int TeamId { get; set; } = 2; //2 je Unassigned
        public Team Team { get; set; }
    }
}
