using ApplicationService.Teams;
using Microsoft.AspNetCore.Mvc;
using Persistence.Core.DTOs;

namespace API.Controllers
{
    public class TeamController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(TeamDTO team)
        {
            return HandleResult(await Mediator.Send(new Create.Command(team)));
        }
    }
}
