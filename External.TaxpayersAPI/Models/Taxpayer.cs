namespace External.TaxpayersAPI.Models
{
    public class Taxpayer
    {
        public string Name { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string StatusVat { get; set; }
        public IEnumerable<string> AccountNumbers { get; set; }

        public Taxpayer()
        {
        }

        public Taxpayer(string name, string nip, string regon, string statusVat, IEnumerable<string> accountNumbers)
        {
            Name = name;
            Nip = nip;
            Regon = regon;
            StatusVat = statusVat;
            AccountNumbers = accountNumbers;
        }
    }
}