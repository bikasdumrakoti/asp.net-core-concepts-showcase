using DistributedCachingWithRedis.Models;
using DistributedCachingWithRedis.ServiceContracts.DTOs;

namespace DistributedCachingWithRedis.ServiceContracts.Extensions
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
