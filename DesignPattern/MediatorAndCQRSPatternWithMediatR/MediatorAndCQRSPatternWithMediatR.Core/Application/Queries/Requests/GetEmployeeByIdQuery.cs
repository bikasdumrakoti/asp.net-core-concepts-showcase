using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatR;

namespace MediatorAndCQRSPatternWithMediatR.Core.Application.Queries.Requests
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeResponseDTO?>;
}
