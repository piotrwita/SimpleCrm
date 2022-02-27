using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SimpleCrm.Application.Dto;
using SimpleCrm.Application.Interfaces;

namespace Application.Queries.Customers.Handlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<GetAllCustomersHandler> _logger;
        private readonly IMemoryCache _memoryCache;

        public GetAllCustomersHandler(ICustomerService customerService, ILogger<GetAllCustomersHandler> logger,
            IMemoryCache memoryCache)
        {
            _customerService = customerService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = _memoryCache.Get<IEnumerable<CustomerDto>>("customers");

            if (customers is null)
            {
                _logger.LogInformation("Fetching from service");
                customers = _customerService.GetAllCustomers();
                _memoryCache.Set("customers", customers, TimeSpan.FromMinutes(1));
            }
            else
             _logger.LogInformation("Fetching from cache");

            return Task.FromResult(customers);
        } 
    }
}

