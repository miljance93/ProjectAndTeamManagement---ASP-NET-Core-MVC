using Domain;

namespace Persistence.Repo.Interfaces
{
    public interface IProjectRepository 
    {
        bool CreateNewProject(Project project);
        IEnumerable<Project> GetAllProjects { get; }
    }
}
