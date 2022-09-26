using Domain;
using Domain.IdentityAuth;

namespace ProjectAndTeamManagement.Models.DepartmentLead
{
    public class RequestModel
    {
        public string EmployeeId { get; set; }
        public IEnumerable<ApplicationUser> Employees { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public int RequestId { get; set; }
        public IEnumerable<Request>? Requests { get; set; }
        public int RequestStatusId { get; set; }
        public IEnumerable<RequestStatus> RequestStatuses { get; set; }
    }
}
