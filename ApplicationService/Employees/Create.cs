using ApplicationService.Core;
using MediatR;
using Persistence.Core.DTOs;
using Persistence.Repo.Interfaces;

namespace ApplicationService.Employees
{
    public class Create
    {
        public record Command(EmployeeDTO Employee) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IEmployeRepository _employeRepository;

            public Handler(IEmployeRepository employeRepository)
            {
                _employeRepository = employeRepository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _employeRepository.CreateAsync(request.Employee);

                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
