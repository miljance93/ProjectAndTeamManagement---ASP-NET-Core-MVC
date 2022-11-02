using ApplicationService.Core;
using MediatR;
using Persistence.Core.DTOs;
using Persistence.Repo.Interfaces;

namespace ApplicationService.Teams
{
    public class Create
    {
        public record Command(TeamDTO Team) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly ITeamRepository _teamRepository;

            public Handler(ITeamRepository teamRepository)
            {
                _teamRepository = teamRepository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                //Prvo proveriti da li postoji tim
                var result = await _teamRepository.CreateAsync(request.Team);

                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
