using Domain;
using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repo.Interfaces
{
    public interface IEmployeeRepository 
    {
        IEnumerable<ApplicationUser> GetAll { get; }
        bool CreateEmployee(ApplicationUser user);
    }
}
