using Domain;
using Domain.IdentityAuth;
using Persistence.Repo.Interfaces;

namespace Persistence.Repo.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAllProjects => _context.Projects.ToList();

        public bool CreateNewProject(Project project)
        {
            bool result;

            try
            {
                _context.Projects.Add(project);
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
