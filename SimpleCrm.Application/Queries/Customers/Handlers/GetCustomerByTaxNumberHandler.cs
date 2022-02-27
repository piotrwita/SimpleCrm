using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SimpleCrm.Application.Dto;
using SimpleCrm.Application.Interfaces;

namespace Application.Queries.Customers.Handlers
{
    public class GetCustomerByTaxNumberHandler : IRequestHandler<GetCustomerByTaxNumberQuery, CustomerDto>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<GetCustomerByTaxNumberHandler> _logger;

        public GetCustomerByTaxNumberHandler(ICustomerService customerService, ILogger<GetCustomerByTaxNumberHandler> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public Task<CustomerDto> Handle(GetCustomerByTaxNumberQuery request, CancellationToken cancellationToken)
        {
            var customer = _customerService.GetCustomerByTaxNumber(request.TaxNumber);
            _logger.LogInformation($"Get customer by taxnumber: {request.TaxNumber}");

            return Task.FromResult(customer);
        }
    }
}

