using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatorAndCQRSPatternWithMediatR.Core.Application.Extensions;
using MediatorAndCQRSPatternWithMediatR.Core.Application.Queries.Requests;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts;
using MediatR;

namespace MediatorAndCQRSPatternWithMediatR.Core.Application.Queries.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployeeByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResponseDTO?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Employee? employee = await _unitOfWork.Employee.GetByIdAsync(request.Id);
            if (employee is not null)
            {
                return employee.ToEmployeeResponse();
            }

            return null;
        }
    }
}
