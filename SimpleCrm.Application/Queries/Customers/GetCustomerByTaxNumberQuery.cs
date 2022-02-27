using MediatR;
using SimpleCrm.Application.Dto;

namespace Application.Queries.Customers
{
    public class GetCustomerByTaxNumberQuery : IRequest<CustomerDto>
    {
        public string TaxNumber { get; }

        public GetCustomerByTaxNumberQuery(string taxNumber)
        {
            TaxNumber = taxNumber;
        }
    }
}
