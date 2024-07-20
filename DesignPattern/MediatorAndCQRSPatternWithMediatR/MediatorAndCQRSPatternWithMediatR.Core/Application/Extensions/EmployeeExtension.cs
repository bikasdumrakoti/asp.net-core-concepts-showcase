using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;

namespace MediatorAndCQRSPatternWithMediatR.Core.Application.Extensions
{
    public static class EmployeeExtension
    {
        public static EmployeeResponseDTO ToEmployeeResponse(this Employee employee)
        {
            return new EmployeeResponseDTO()
            {
                Id = employee.Id,
                Name = employee.Name
            };
        }
    }
}
