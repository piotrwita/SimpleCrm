using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SimpleCrm.Application.Dto;
using SimpleCrm.Application.Interfaces;

namespace Application.Queries.Customers.Handlers
{
    public class GetAllCustomersAsyncHandler : IRequestHandler<GetAllCustomersAsyncQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<GetAllCustomersAsyncHandler> _logger;
        private readonly IMemoryCache _memoryCache;

        public GetAllCustomersAsyncHandler(ICustomerService customerService, ILogger<GetAllCustomersAsyncHandler> logger,
            IMemoryCache memoryCache)
        {
            _customerService = customerService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersAsyncQuery request, CancellationToken cancellationToken)
        {
            var customers = _memoryCache.Get<IEnumerable<CustomerDto>>("customers");

            if (customers is null)
            {
                _logger.LogInformation("Fetching from service");
                customers = await _customerService.GetAllCustomersAsync();    
                _memoryCache.Set("customers", customers, TimeSpan.FromMinutes(1));
                return customers;
            }

             _logger.LogInformation("Fetching from cache");
            return await Task.FromResult(customers);
        }
    }
}

