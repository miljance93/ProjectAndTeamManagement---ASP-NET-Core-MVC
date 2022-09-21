using Domain.IdentityAuth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Team
    {
        public int TeamId { get; set; } 
        public string TeamName { get; set; }
        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
        public string? TeamLeadId { get; set; }
        public List<ApplicationUser>? ApplicationEmployees { get; set; }
    }
}
