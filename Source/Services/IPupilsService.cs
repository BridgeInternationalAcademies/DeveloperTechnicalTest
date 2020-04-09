namespace Grade.Promoter.Services
{
    using System.Collections.Generic;
    using Grade.Promoter.Models;
    using Grade.Promoter.ViewModels;

    public interface IPupilsService
    {
        List<Pupil> GeneratePromotionResults(List<ExamResult> examResults);
    }
}