using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SimpleCrm.Application.Dto;
using SimpleCrm.Application.Interfaces;

namespace Application.Queries.Customers.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<GetCustomerByIdHandler> _logger;

        public GetCustomerByIdHandler(ICustomerService customerService, ILogger<GetCustomerByIdHandler> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = _customerService.GetCustomerById(request.Id);
            _logger.LogInformation($"Get customer by id: {request.Id}");

            return Task.FromResult(customer);
        }
    }
}

