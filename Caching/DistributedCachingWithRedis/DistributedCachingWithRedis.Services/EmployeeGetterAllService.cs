using DistributedCachingWithRedis.Models;
using DistributedCachingWithRedis.RepositoryContracts;
using DistributedCachingWithRedis.ServiceContracts.DTOs;
using DistributedCachingWithRedis.ServiceContracts.Extensions;
using DistributedCachingWithRedis.ServiceContracts.ServiceContracts;

namespace DistributedCachingWithRedis.Services
{
    public class EmployeeGetterAllService : IEmployeeGetterAllService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeGetterAllService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> GetAllEmployees()
        {
            IEnumerable<Employee> employees = await _unitOfWork.Employee.GetAllAsync();
            return employees.Select(x => x.ToEmployeeResponse());
        }
    }
}
