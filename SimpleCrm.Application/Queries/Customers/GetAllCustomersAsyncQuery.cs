using MediatR;
using SimpleCrm.Application.Dto;

namespace Application.Queries.Customers
{
    public class GetAllCustomersAsyncQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public GetAllCustomersAsyncQuery()
        {

        }
    }
}
