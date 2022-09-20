using Domain.IdentityAuth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; } 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string  Path { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team? Team { get; set; }
        public int? ProjectStatusId { get; set; }
        [ForeignKey("ProjectStatusId")]
        public ProjectStatus? ProjectStatus { get; set; }
        public string? ProjectLeadId { get; set; }
        [ForeignKey("ProjectLeadId")]
        public ApplicationUser? ProjectLead { get; set; }
    }
}
