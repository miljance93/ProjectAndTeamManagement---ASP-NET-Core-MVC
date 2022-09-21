using Domain;
using Domain.IdentityAuth;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectAndTeamManagement.Models.DepartmentLead
{
    public class CreateNewProject
    {
        [Required(ErrorMessage = "Name of project is required!")]
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Path { get; set; }
        public string? EmployeeId { get; set; }
        public IEnumerable<ApplicationUser>? Employees { get; set; }
        public int ProjectStatusId { get; set; }
        public IEnumerable<ProjectStatus>? ProjectStatuses { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<IdentityRole>? Roles { get; set; }
    }
}
