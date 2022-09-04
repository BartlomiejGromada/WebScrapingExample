using System.Text;

namespace WebScraping.Entity
{
    public class Country
    {
        public string? Name { get; set; }
        public string? Area { get; set; }
        public string? Population { get; set; }
        public string? Iso { get; set; }
        public string? Capital { get; set; }
        public string? Continent { get; set; }
        public string? Tld { get; set; }
        public string? CurrencyCode { get; set; }
        public string? CurrencyName { get; set; }
        public string? Phone { get; set; }
        public string? PostalCodeFormat { get; set; }
        public string? Languages { get; set; }
        public IEnumerable<Country>? Neighbours { get; set; }

        public override string? ToString()
        {
            var sb = new StringBuilder($"Name: {Name} - Area: {Area} - Population: {Population} - Iso {Iso} " +
                $"Capital: {Capital} - Continent: {Continent} - CurrencyCode: {CurrencyCode} " +
                $"CurrencyName: {CurrencyName} - Phone: {Phone} - PostalCodeFormat: {PostalCodeFormat} " +
                $"Languages: {Languages} ");
            Neighbours?.ToList().ForEach((country) => sb.Append($"{country.Name} "));

            return sb.ToString();
        }
    }
}
