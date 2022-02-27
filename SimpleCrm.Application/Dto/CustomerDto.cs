using AutoMapper;
using SimpleCrm.Application.Mappings;
using SimpleCrm.Domain.Entities;

namespace SimpleCrm.Application.Dto
{
    public class CustomerDto : IMap
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string StatusVat { get; set; }

        public IEnumerable<string> AccountNumbers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>();
        }
    }
}
