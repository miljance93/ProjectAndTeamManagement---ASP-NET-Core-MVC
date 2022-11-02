using ApplicationService.Core;
using Domain;
using MediatR;
using Persistence.Core.DTOs;
using Persistence.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Projects
{
    public class List
    {
        public record Query : IRequest<Result<List<ProjectDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<ProjectDTO>>>
        {
            private readonly IProjectRepository _projectRepository;

            public Handler(IProjectRepository projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Result<List<ProjectDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _projectRepository.GetAllAsync<ProjectDTO>();
                var listOfProjects = result.ToList();

                if (result != null)
                {
                    return new Result<List<ProjectDTO>> { IsSuccess = true, Value = listOfProjects };
                }

                return new Result<List<ProjectDTO>> { IsSuccess = false, Error = "No projects found" };
            }
        }
    }
}
