using MediatorAndCQRSPatternWithMediatR.Core.Application.Commands.Requests;
using MediatorAndCQRSPatternWithMediatR.Core.Application.DTOs;
using MediatorAndCQRSPatternWithMediatR.Core.Application.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorAndCQRSPatternWithMediatR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeResponseDTO>> Get()
        {
            return await _mediator.Send(new GetAllEmployeeQuery());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeResponseDTO?> Get(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<EmployeeResponseDTO> Post([FromBody] EmployeeAddRequestDTO employeeAddRequestDTO)
        {
            return await _mediator.Send(new CreateEmployeeCommand(employeeAddRequestDTO));
        }
    }
}
