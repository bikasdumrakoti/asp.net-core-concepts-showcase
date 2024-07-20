using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatR;

namespace MediatorAndCQRSPatternWithMediatR.Core.Application.Commands.Requests
{
    public record CreateEmployeeCommand(EmployeeAddRequestDTO EmployeeAddRequestDTO) : IRequest<EmployeeResponseDTO>;
}
