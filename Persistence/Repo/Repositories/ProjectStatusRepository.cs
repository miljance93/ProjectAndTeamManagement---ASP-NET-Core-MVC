using Domain;
using Persistence.Repo.Interfaces;

namespace Persistence.Repo.Repositories
{
    public class ProjectStatusRepository : IProjectStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProjectStatus> GetAllProjectStatuses => _context.ProjectStatuses.ToList();
    }
}
