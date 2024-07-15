using InMemoryCaching.Models;
using InMemoryCaching.ServiceContracts.DTOs;

namespace InMemoryCaching.ServiceContracts.Extensions
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
