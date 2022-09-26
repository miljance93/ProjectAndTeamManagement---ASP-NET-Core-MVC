using Domain.IdentityAuth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string? DepartmentLeadId { get; set; }
        public string? ProjectLeadId { get; set; }
        public string? TeamLeadId { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public ApplicationUser Employee { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? RequestStatusId { get; set; }
        [ForeignKey("RequestStatusId")]
        public RequestStatus? RequestStatus { get; set; }

    }
}
