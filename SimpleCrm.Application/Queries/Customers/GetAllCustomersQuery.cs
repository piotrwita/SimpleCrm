using MediatR;
using SimpleCrm.Application.Dto;

namespace Application.Queries.Customers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public GetAllCustomersQuery()
        {

        }
    }
}
