using Domain;
using Domain.IdentityAuth;
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
        public IEnumerable<ApplicationUser> GetAll
        {
            get
            {
                return _context.Users.ToList();
            }
        }

        public bool CreateEmployee(ApplicationUser user)
        {
            bool result;

            try
            {
                _context.Users.Add(user);
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
