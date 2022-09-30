using Domain;
using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class EmployeeRequestService
    {
        public string LeadId { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<ApplicationUser>? Employees { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<Project>? Projects { get; set; }
        public int RequestStatusId { get; set; } = 1;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
