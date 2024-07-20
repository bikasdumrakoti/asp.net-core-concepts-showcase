using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatorAndCQRSPatternWithMediatR.Core.Application.Queries.Requests;
using MediatorAndCQRSPatternWithMediatR.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediatorAndCQRSPatternWithMediatR.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<EmployeeResponseDTO> employeeResponseDTOs = await _mediator.Send(new GetAllEmployeeQuery());

            List<EmployeeViewModel> employeeViewModels = new();

            foreach (var employeeResponseDTO in employeeResponseDTOs)
            {
                employeeViewModels.Add(new()
                {
                    Id = employeeResponseDTO.Id,
                    Name = employeeResponseDTO.Name
                });
            }

            return View(employeeViewModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
