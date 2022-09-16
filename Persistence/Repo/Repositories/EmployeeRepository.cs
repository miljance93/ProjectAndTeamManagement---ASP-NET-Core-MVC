using Domain;
using Persistence.Repo.Interfaces;

namespace Persistence.Repo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll
        {
            get
            {
                return _context.Employees.ToList();
            }
        }

        public bool CreateEmployee(Employee employee)
        {
            bool result;

            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
