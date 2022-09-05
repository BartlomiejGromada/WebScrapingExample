using WebScraping.Entity;
using WebScraping.Interfaces;
using WebScraping.WebScraping;


IImportableToExcel<Country?> countriesScraping = new CountriesScraping();
var countries = countriesScraping.GetItems().ToList();
countriesScraping.SaveToExcelFile(countries, @"C:\c#\nauka\WebScrapingExamples\WebScraping\files\countries.xlsx");


IImportableToExcel<Footballer?> footballersScraping = new FootballersScraping();
var footballers = footballersScraping.GetItems().ToList();
footballersScraping.SaveToExcelFile(footballers, @"C:\c#\nauka\WebScrapingExamples\WebScraping\files\footballers.xlsx");
