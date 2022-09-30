using Application.Models;
using Application.Services.Interfaces;
using Domain;
using Domain.IdentityAuth;
using Persistence.Repo.Interfaces;

namespace Application.Services
{
    public class ProjectLeadService : IProjectLeadService
    {
        private readonly IRequestRepository _requestRepository;

        public ProjectLeadService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public bool CreateNewRequest(EmployeeRequestService request, ApplicationUser projectLeadId)
        {
            try
            {
                var requestForEmployee = new Request
                {
                    EmployeeId = request.EmployeeId,
                    DepartmentLeadId = request.LeadId,
                    ProjectLeadId = projectLeadId.Id,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    ProjectId = request.ProjectId,
                    RequestStatusId = request.RequestStatusId,
                    TeamLeadId = request.LeadId
                };

                _requestRepository.CreateNewRequest(requestForEmployee);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
