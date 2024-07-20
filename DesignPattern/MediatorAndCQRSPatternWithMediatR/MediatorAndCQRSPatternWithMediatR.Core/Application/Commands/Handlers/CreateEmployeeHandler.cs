using MediatorAndCQRSPatternWithMediatR.Core.Application.Commands.Requests;
using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatorAndCQRSPatternWithMediatR.Core.Application.Extensions;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts;
using MediatR;

namespace MediatorAndCQRSPatternWithMediatR.Core.Application.Commands.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResponseDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await _unitOfWork.Employee.CreateAsync(request.EmployeeAddRequestDTO.ToEmployee());
            await _unitOfWork.Save();
            return employee.ToEmployeeResponse();
        }
    }
}
