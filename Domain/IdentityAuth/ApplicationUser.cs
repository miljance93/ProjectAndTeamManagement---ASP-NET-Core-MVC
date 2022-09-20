using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.IdentityAuth
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team? Team { get; set; }
        public Project? Project { get; set; }
        public string? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public IdentityRole? Role { get; set; }
    }
}
