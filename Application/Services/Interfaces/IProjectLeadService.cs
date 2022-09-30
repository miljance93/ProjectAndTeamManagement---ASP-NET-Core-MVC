using Application.Models;
using Domain.IdentityAuth;

namespace Application.Services.Interfaces
{
    public interface IProjectLeadService
    {
        bool CreateNewRequest(EmployeeRequestService employeeRequest, ApplicationUser projectLeadId);
    }
}
