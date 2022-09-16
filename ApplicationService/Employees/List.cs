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
    public class List
    {
        public record Query : IRequest<Result<List<EmployeeDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<EmployeeDTO>>>
        {
            private readonly IEmployeRepository _employeRepository;

            public Handler(IEmployeRepository employeRepository)
            {
               _employeRepository = employeRepository;
            }
            public async Task<Result<List<EmployeeDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _employeRepository.GetAllAsync<EmployeeDTO>();

                if (result != null)
                {
                    return new Result<List<EmployeeDTO>> { IsSuccess = true, Value = result.ToList() };
                }

                return new Result<List<EmployeeDTO>> { IsSuccess = false, Error = "List of employees not found" };
            }
        }
    }
}
