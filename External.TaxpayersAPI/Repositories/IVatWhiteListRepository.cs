using External.TaxpayersAPI.Models;

namespace External.TaxpayersAPI.Repositories
{
    public interface IVatWhiteListRepository
    {
        Task<IEnumerable<Taxpayer>> GetAsync();
    }
}
