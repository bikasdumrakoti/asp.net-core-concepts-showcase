using DistributedCachingWithRedis.ServiceContracts.DTOs;
using DistributedCachingWithRedis.ServiceContracts.ServiceContracts;
using DistributedCachingWithRedis.Utilities.Constants;
using DistributedCachingWithRedis.Web.Extensions;
using DistributedCachingWithRedis.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;

namespace DistributedCachingWithRedis.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeGetterAllService _employeeGetterAllService;
        private readonly IDistributedCache _distributedCache;

        public HomeController(ILogger<HomeController> logger, IEmployeeGetterAllService employeeGetterAllService, IDistributedCache distributedCache)
        {
            _logger = logger;
            _employeeGetterAllService = employeeGetterAllService;
            _distributedCache = distributedCache;
        }

        public async Task<IActionResult> Index()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<EmployeeViewModel>? employeeViewModels = await _distributedCache.GetRecordAsync<List<EmployeeViewModel>>(ApplicationConstant.EmployeeCacheKey);
            if (employeeViewModels is not null)
            {
                _logger.LogInformation("Employees found in cache. Skipping loading from database ...");
            }
            else
            {
                _logger.LogInformation("Employees not found in cache. Loading from database ...");

                IEnumerable<EmployeeResponseDTO> employeeResponseDTOs = await _employeeGetterAllService.GetAllEmployees();

                employeeViewModels = new();

                foreach (EmployeeResponseDTO employeeResponseDTO in employeeResponseDTOs)
                {
                    employeeViewModels.Add(new()
                    {
                        Id = employeeResponseDTO.Id,
                        Name = employeeResponseDTO.Name
                    });
                }

                await _distributedCache.SetRecordAsync(ApplicationConstant.EmployeeCacheKey, employeeViewModels, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(30));
            }
            stopwatch.Stop();

            _logger.LogInformation("Elapsed time : " + stopwatch.ElapsedMilliseconds + " milliseconds.");

            return View(employeeViewModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ClearCache()
        {
            _distributedCache.Remove(ApplicationConstant.EmployeeCacheKey);

            _logger.LogInformation("Cache cleared.");

            return RedirectToAction(nameof(Index));
        }
    }
}
