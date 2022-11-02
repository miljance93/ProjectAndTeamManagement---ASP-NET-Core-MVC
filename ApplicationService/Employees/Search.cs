using ApplicationService.Core;
using MediatR;
using Persistence.Core.DTOs;
using Persistence.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Employees
{
    public class Search
    {
        public record Query(int Id) : IRequest<Result<EmployeeDTO>>;

        public class Handler : IRequestHandler<Query, Result<EmployeeDTO>>
        {
            private readonly IEmployeRepository _employeRepository;

            public Handler(IEmployeRepository employeRepository)
            {
                _employeRepository = employeRepository;
            }
            public async Task<Result<EmployeeDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var result = await _employeRepository.GetByIdAsync<EmployeeDTO>(x => x.Id == request.Id);
                if (result != null)
                {
                    return new Result<EmployeeDTO> { IsSuccess = true, Value = result };
                }

                return new Result<EmployeeDTO> { IsSuccess = false, Error = "Employee not found " };
            }
        }
    }
}
