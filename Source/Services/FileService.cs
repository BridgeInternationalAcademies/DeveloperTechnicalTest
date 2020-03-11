namespace Grade.Promotions.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using CsvHelper.Configuration;
    using Grade.Promotions.ViewModels;

    public class FileService : IFileService
    {
        public List<ExamResult> ParseExamResultsFromCsv(string filepath)
        {
            using (var fileReader = File.OpenText(filepath))
            {
                var csv = new CsvReader(fileReader, new CsvConfiguration(CultureInfo.InvariantCulture), leaveOpen: false);
                csv.Configuration.HasHeaderRecord = false;
                csv.Read();
                var examResult = csv.GetRecords<ExamResult>().ToList();
                return examResult;
            }
        }
    }
}
