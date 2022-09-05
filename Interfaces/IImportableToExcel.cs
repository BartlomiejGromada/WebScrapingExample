using Aspose.Cells;
using Range = Aspose.Cells.Range;

namespace WebScraping.Interfaces
{
    public interface IImportableToExcel<T>
    {
        public IEnumerable<T> GetItems();
        public void SaveToExcelFile(IEnumerable<T> items, string filePath)
        {
            Console.WriteLine("START IMPORTING TO EXCEL FILE");
            var workBook = new Workbook();
            var propertyNames = typeof(T).GetProperties()
                .Select(p => p.Name)
                .ToArray();
            // When you create a new workbook, a default "Sheet1" is added to the workbook.
            Worksheet sheet = workBook.Worksheets[0];
           
            sheet.Cells.ImportCustomObjects(items.ToList(), propertyNames, true, 0, 0,
                int.MaxValue, true, "MM-dd-YYYY", false);
            workBook.Save(filePath, SaveFormat.Xlsx);
            //workBook.Save(@"C:\c#\nauka\WebScrapingExamples\WebScraping\files\countries.xlsx", SaveFormat.Xlsx);
            Console.WriteLine("END IMPORTING TO EXCEL FILE");
        }
    }
}
