using MediatR;
using SimpleCrm.Application.Dto;

namespace Application.Queries.Customers
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; } 

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
