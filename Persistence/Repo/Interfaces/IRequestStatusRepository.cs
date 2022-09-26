using Domain;

namespace Persistence.Repo.Interfaces
{
    public interface IRequestStatusRepository
    {
        IEnumerable<RequestStatus> GetAllRequestStatuses { get; }
    }
}
