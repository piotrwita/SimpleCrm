namespace SimpleCrm.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string StatusVat { get; set; }

        public IEnumerable<string> AccountNumbers { get; set; }

        public Customer()
        {

        }

        public Customer(Guid id, string name, string taxNumber, string email, string phoneNumber,
            string statusVat, IEnumerable<string> accountNumbers)
        {
            Id = id;
            Name = name;
            TaxNumber = taxNumber;
            Email = email;
            PhoneNumber = phoneNumber;
            StatusVat = statusVat;
            AccountNumbers = accountNumbers;
        }
    }
}
