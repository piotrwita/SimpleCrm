using SimpleCrm.Domain.Entities;

namespace SimpleCrm.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Customer GetById(Guid id);

        Customer GetByTaxNumber(string taxNumber);

        IQueryable<Customer> GetAll();
    }
}
