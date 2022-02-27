using SimpleCrm.Application.Dto;

namespace SimpleCrm.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(Guid id);
        CustomerDto GetCustomerByTaxNumber(string taxNumber);
    }
}
