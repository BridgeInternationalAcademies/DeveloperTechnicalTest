using GradePromoter.Models;
using GradePromoter.ViewModels;
using System.Collections.Generic;

namespace GradePromoter.Services
{
    public interface IFileService
    {
        List<ExamResult> ParseExamResultsFromCsv(string filepath);

        string WritePromotionResults(List<Pupil> pupils, string outputPath);
    }
}