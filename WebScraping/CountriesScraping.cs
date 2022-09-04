using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using WebScraping.Entity;

namespace WebScraping.WebScraping
{
    public class CountriesScraping
    {
        private const string COUNTRIES_WEB_LINK = @"http://example.python-scraping.com";
        private readonly HtmlWeb _web;
        public CountriesScraping()
        {
            _web = new HtmlWeb();
        }
        public IEnumerable<Country?> GetCountries()
        {
            var countryLinks = GetAllCountriesLinks();

            foreach (var link in countryLinks)
            {
                yield return GetCountryInfo(link);
            }
        }

        private List<string> GetAllCountriesLinks()
        {
            var countriesLinks = new List<string>();
            int counter = 0;
            HtmlDocument? htmlDoc;
            do
            {
                htmlDoc = _web.Load($"http://example.python-scraping.com/places/default/index/{counter}");
                countriesLinks.AddRange(GetLinksFromOneSite(htmlDoc));
                counter++;
            } while (IsNextPage(htmlDoc));

            return countriesLinks;
        }

        private static IEnumerable<string> GetLinksFromOneSite(HtmlDocument htmlDoc)
        {
            var links = new List<string>();
            var items = htmlDoc.QuerySelectorAll("td div a");
            foreach (var item in items)
            {
                var link = item.GetAttributes().FirstOrDefault(a => a.Name == "href");
                if (link != null)
                {
                    yield return $"{COUNTRIES_WEB_LINK}{link.Value}";
                }
            }
        }

        private static bool IsNextPage(HtmlDocument htmlDoc)
        {
            var pagination = htmlDoc.QuerySelectorAll("div#pagination a");
            var nextButton = pagination.FirstOrDefault(pi => pi.InnerText.Contains("Next"));
            var nextLink = nextButton?.GetAttributes().FirstOrDefault(a => a.Name == "href");
            return nextLink != null;
        }

        private Country? GetCountryInfo(string url)
        {
            var htmlDoc = _web.Load(url);
            var rows = htmlDoc.QuerySelectorAll("tr td.w2p_fw").Skip(1).ToList();

            if (rows != null && rows.Count > 0)
            {
                var country = new Country()
                {
                    Area = rows[0].InnerText,
                    Population = rows[1].InnerText,
                    Iso = rows[2].InnerText,
                    Name = rows[3].InnerText,
                    Capital = rows[4].InnerText,
                    Continent = rows[5].InnerText,
                    Tld = rows[6].InnerText,
                    CurrencyCode = rows[7].InnerText,
                    CurrencyName = rows[8].InnerText,
                    Phone = rows[9].InnerText,
                    PostalCodeFormat = rows[10].InnerText,
                    Languages = rows[12].InnerText,
                };

                return country;
            }

            return null;
        }

    }
}
