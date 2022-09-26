using Domain;
using Persistence.Repo.Interfaces;

namespace Persistence.Repo.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateNewRequest(Request request)
        {
            bool result;

            try
            {
                _context.Requests.Add(request);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public bool UpdateRequest(Request request)
        {
            bool result;

            try
            {
                _context.Requests.Update(request);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public IEnumerable<Request> GetAllRequests => _context.Requests.ToList();
    }
}
