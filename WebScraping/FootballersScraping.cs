using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using WebScraping.Entity;
using WebScraping.Interfaces;

namespace WebScraping.WebScraping
{
    public class FootballersScraping : IImportableToExcel<Footballer?>
    {
        private const string FOOTBALLERS_WEB_LINK = @"https://www.theguardian.com/football/datablog/2012/dec/24/world-best-footballers-top-100-list#data";
        private readonly HtmlWeb _web;

        public FootballersScraping()
        {
            _web = new HtmlWeb();
        }
        public IEnumerable<Footballer?> GetItems()
        {
            Console.WriteLine("START GETTING FOOTBALLERS....");
            var htmlDoc = _web.Load(FOOTBALLERS_WEB_LINK);
            var rows = htmlDoc.QuerySelectorAll("table tbody tr");
            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                int.TryParse(row.QuerySelector($"td #table-cell-11683-{i}-0").InnerText, out int id);
                var fullName = row.QuerySelector($"td #table-cell-11683-{i}-1").InnerText;
                var position = row.QuerySelector($"td #table-cell-11683-{i}-2").InnerText;
                var club = row.QuerySelector($"td #table-cell-11683-{i}-3").InnerText;
                var nationality = row.QuerySelector($"td #table-cell-11683-{i}-4").InnerText;
                int.TryParse(row.QuerySelector($"td #table-cell-11683-{i}-5").InnerText, out int age);

                var footballer = new Footballer(id, fullName, position, club, nationality, age);
                Console.WriteLine(footballer);
                yield return footballer;
            }
            Console.WriteLine("END GETTING FOOTBALLERS....");
        }
    }
}
