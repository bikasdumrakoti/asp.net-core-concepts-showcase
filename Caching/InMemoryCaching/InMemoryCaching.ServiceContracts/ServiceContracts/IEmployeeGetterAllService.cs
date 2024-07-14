using InMemoryCaching.ServiceContracts.DTOs;

namespace InMemoryCaching.ServiceContracts.ServiceContracts
{
    public interface IEmployeeGetterAllService
    {
        Task<IEnumerable<EmployeeResponse>> GetAllEmployees();
    }
}
