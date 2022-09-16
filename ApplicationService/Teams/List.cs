using ApplicationService.Core;
using MediatR;
using Persistence.Core.DTOs;
using Persistence.Repo.Interfaces;

namespace ApplicationService.Teams
{
    public class List
    {
        public record Query : IRequest<Result<List<TeamDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<TeamDTO>>>
        {
            private readonly ITeamRepository _teamRepository;

            public Handler(ITeamRepository teamRepository)
            {
                _teamRepository = teamRepository;
            }

            public async Task<Result<List<TeamDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _teamRepository.GetAllAsync<TeamDTO>();
                var listOfTeams = result.ToList();

                if (result != null)
                {
                    return new Result<List<TeamDTO>> { IsSuccess = true, Value = listOfTeams };
                }

                return new Result<List<TeamDTO>> { IsSuccess = false, Error = "No teams found" };
            }
        }
    }
}
