using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repo.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeams { get; }
        Team GetTeamById(int id);

        bool CreateNewTeam(Team team);
    }
}
