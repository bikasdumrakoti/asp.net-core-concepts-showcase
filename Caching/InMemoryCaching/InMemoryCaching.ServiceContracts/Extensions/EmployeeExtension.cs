using InMemoryCaching.Models;
using InMemoryCaching.ServiceContracts.DTOs;

namespace InMemoryCaching.ServiceContracts.Extensions
{
    public static class EmployeeExtension
    {
        public static EmployeeResponse ToEmployeeResponse(this Employee employee)
        {
            return new EmployeeResponse()
            {
                Id = employee.Id,
                Name = employee.Name
            };
        }
    }
}
