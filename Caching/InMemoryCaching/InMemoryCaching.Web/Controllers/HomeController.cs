using InMemoryCaching.ServiceContracts.DTOs;
using InMemoryCaching.ServiceContracts.ServiceContracts;
using InMemoryCaching.Utilities.Constants;
using InMemoryCaching.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace InMemoryCaching.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeGetterAllService _employeeGetterAllService;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IEmployeeGetterAllService employeeGetterAllService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _employeeGetterAllService = employeeGetterAllService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<EmployeeViewModel>? employeeViewModels = _memoryCache.Get<List<EmployeeViewModel>>(ApplicationConstant.EmployeeCacheKey);
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

                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                    .SetPriority(CacheItemPriority.Normal);

                _memoryCache.Set(ApplicationConstant.EmployeeCacheKey, employeeViewModels, memoryCacheEntryOptions);
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
            _memoryCache.Remove(ApplicationConstant.EmployeeCacheKey);

            _logger.LogInformation("Cache cleared.");

            return RedirectToAction(nameof(Index));
        }
    }
}
