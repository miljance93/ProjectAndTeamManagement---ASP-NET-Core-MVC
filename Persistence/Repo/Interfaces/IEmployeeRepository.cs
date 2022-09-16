using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repo.Interfaces
{
    public interface IEmployeeRepository 
    {
        IEnumerable<Employee> GetAll { get; }
        bool CreateEmployee(Employee employee);
    }
}
