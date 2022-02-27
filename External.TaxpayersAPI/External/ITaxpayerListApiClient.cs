using External.TaxpayersAPI.Models;

namespace External.TaxpayersAPI.External
{
    public interface ITaxpayerListApiClient
    {
        Task<IEnumerable<Taxpayer>> GetAsync();
    }
}
