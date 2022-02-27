using External.TaxpayersAPI.Models;
using External.TaxpayersAPI.Repositories;

namespace External.TaxpayersAPI.External
{
    public class TaxpayerListApiClient : ITaxpayerListApiClient
    {
        private readonly IVatWhiteListRepository _repository;

        public TaxpayerListApiClient(IVatWhiteListRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Taxpayer>> GetAsync()
        {
            return await _repository.GetAsync();
        }
    }
}
