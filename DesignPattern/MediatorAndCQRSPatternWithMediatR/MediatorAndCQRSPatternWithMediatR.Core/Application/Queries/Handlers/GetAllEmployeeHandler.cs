using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatorAndCQRSPatternWithMediatR.Core.Application.Extensions;
using MediatorAndCQRSPatternWithMediatR.Core.Application.Queries.Requests;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts;
using MediatR;

namespace MediatorAndCQRSPatternWithMediatR.Core.Application.Queries.Handlers
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEmployeeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Employee> employees = await _unitOfWork.Employee.GetAllAsync();
            return employees.Select(x => x.ToEmployeeResponse());
        }
    }
}
