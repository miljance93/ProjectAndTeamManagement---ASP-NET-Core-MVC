using Domain;
using Persistence.Repo.Interfaces;

namespace Persistence.Repo.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAllTeams => _context.Teams.ToList();

        public bool CreateNewTeam(Team team)
        {
            bool result;

            try
            {
                _context.Teams.Add(team);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.FirstOrDefault(x => x.TeamId == id);
        }
    }
}
