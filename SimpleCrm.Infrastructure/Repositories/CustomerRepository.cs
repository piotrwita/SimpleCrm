using External.TaxpayersAPI.External;
using SimpleCrm.Domain.Entities;
using SimpleCrm.Domain.Interfaces;

namespace SimpleCrm.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public ITaxpayerListApiClient _taxpayerListApiClient { get; }

        public CustomerRepository(ITaxpayerListApiClient taxpayerListApiClient)
        {
            _taxpayerListApiClient = taxpayerListApiClient;
        }

        private readonly HashSet<Customer> _customers = new HashSet<Customer>()
        {
            new Customer() 
            { 
                Id = Guid.NewGuid(),
                Name = "COCA-COLA HBC POLSKA SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ", 
                Email = "j.kowalski@gmail.com", 
                PhoneNumber = "698654632"      
            },
            new Customer() 
            {
                Id = Guid.NewGuid(),
                Name = "COMARCH SPÓŁKA AKCYJNA", 
                TaxNumber = "6770065406", 
                Email = "info@comarch.pl", 
                PhoneNumber = "(12)6461000"
            },
            new Customer() 
            {
                Id = Guid.NewGuid(),
                Name = "MUZEUM WOJSKA, WOJSKOWOŚCI I ZIEMI ORZYSZKIEJ W ORZYSZU (W ORGANIZACJI)", 
                TaxNumber = "8971813098", 
                Email = "pomoc@sellintegro.pl", 
                PhoneNumber = "+48796300116"
            }
        };

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var taxpayers = await _taxpayerListApiClient.GetAsync();
            return _customers.Join(taxpayers,
                                c => c.Name,
                                t => t.Name,
                                (c, t) => new Customer 
                                { 
                                    Id = c.Id, 
                                    Name = c.Name, 
                                    TaxNumber = c.TaxNumber, 
                                    Email = c.Email, 
                                    PhoneNumber = c.PhoneNumber, 
                                    StatusVat = t.StatusVat, 
                                    AccountNumbers = t.AccountNumbers 
                                }).ToList();
        }

        public IQueryable<Customer> GetAll() 
            => _customers.AsQueryable();
        

        public Customer GetById(Guid id) 
            => _customers.AsQueryable().SingleOrDefault(x => x.Id == id);
        

        public Customer GetByTaxNumber(string taxNumber) 
            => _customers.AsQueryable().SingleOrDefault(x => x.TaxNumber == taxNumber);
    }
}
