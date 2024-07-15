using DistributedCachingWithRedis.ServiceContracts.DTOs;

namespace DistributedCachingWithRedis.ServiceContracts.ServiceContracts
{
    public interface IEmployeeGetterAllService
    {
        Task<IEnumerable<EmployeeResponseDTO>> GetAllEmployees();
    }
}
