using Domain.IdentityAuth;

namespace Persistence.Repo.Interfaces
{
    public interface IEmployeeRepository 
    {
        IEnumerable<ApplicationUser> GetAll { get; }
        bool CreateEmployee(ApplicationUser user);
        bool UpdateEmployee(ApplicationUser user);
    }
}
