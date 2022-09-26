using Domain;
using Persistence.Repo.Interfaces;

namespace Persistence.Repo.Repositories
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<RequestStatus> GetAllRequestStatuses => _context.RequestStatuses.ToList();   
    }
}
