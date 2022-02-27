using Application.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCrm.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SimpleCrm.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator =
                mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [SwaggerOperation(Summary = "Retrieves all customers")]
        [HttpGet("Get4Report")]
        public async Task<IActionResult> GetAllAsync()
        {
            var customersQuery = new GetAllCustomersAsyncQuery();
            var customers = await _mediator.Send(customersQuery);

            return Ok(customers);
        }

        [SwaggerOperation(Summary = "Retrieves all customers")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var customersQuery = new GetAllCustomersQuery();
            var customers = _mediator.Send(customersQuery);

            return Ok(customers);
        }

        [SwaggerOperation(Summary = "Retrieves a specific customer by unique id")]
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var customerQuery = new GetCustomerByIdQuery(id);
            var customer = _mediator.Send(customerQuery);

            return customer != null ? Ok(customer) : NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves a specific customer by tax number")]
        [HttpGet("[action]/{taxNumber}")]
        public IActionResult GetByTaxNumber(string taxNumber)
        {
            var customerQuery = new GetCustomerByTaxNumberQuery(taxNumber);
            var customer = _mediator.Send(customerQuery);

            return customer != null ? Ok(customer) : NotFound();
        }
    }
}
