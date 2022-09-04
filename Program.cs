using WebScraping.WebScraping;

//var countriesScraping = new CountriesScraping();
//Console.WriteLine("Country list");

//foreach (var country in countriesScraping.GetCountries())
//{
//    Console.WriteLine(country);
//}

var footballerScraping = new FootballersScraping();
foreach (var footballer in footballerScraping.GetFootballers())
{
    Console.WriteLine(footballer);
}