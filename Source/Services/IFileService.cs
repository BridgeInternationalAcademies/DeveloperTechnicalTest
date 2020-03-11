namespace Grade.Promotions.Services
{
    using System.Collections.Generic;
    using Grade.Promotions.ViewModels;

    public interface IFileService
    {
        List<ExamResult> ParseExamResultsFromCsv(string filepath);
    }
}