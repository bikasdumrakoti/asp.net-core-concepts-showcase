using InMemoryCaching.Models;
using InMemoryCaching.RepositoryContracts;
using InMemoryCaching.ServiceContracts.DTOs;
using InMemoryCaching.ServiceContracts.Extensions;
using InMemoryCaching.ServiceContracts.ServiceContracts;

namespace InMemoryCaching.Services
{
    public class EmployeeGetterAllService : IEmployeeGetterAllService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeGetterAllService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployees()
        {
            IEnumerable<Employee> employees = await _unitOfWork.Employee.GetAllAsync();
            return employees.Select(x => x.ToEmployeeResponse());
        }
    }
}
