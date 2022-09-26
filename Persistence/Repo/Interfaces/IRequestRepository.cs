using Domain;

namespace Persistence.Repo.Interfaces
{
    public interface IRequestRepository
    {
        bool CreateNewRequest(Request request);
        bool UpdateRequest(Request request);
        IEnumerable<Request> GetAllRequests { get; }
    }
}
