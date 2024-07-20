using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.Entities;

namespace MediatorAndCQRSPatternWithMediatR.Core.Application.Extensions
{
    public static class EmployeeAddRequestExtension
    {
        public static Employee ToEmployee(this EmployeeAddRequestDTO entity)
        {
            return new Employee()
            {
                Name = entity.Name
            };
        }
    }
}
