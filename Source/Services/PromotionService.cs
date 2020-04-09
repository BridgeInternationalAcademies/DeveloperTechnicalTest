namespace Grade.Promoter.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Grade.Promoter.Factories;
    using Grade.Promoter.Models;
    using Grade.Promoter.ViewModels;

    public class PromotionService : IPromotionService
    {
        private readonly IPupilFactory pupilFactory;

        public PromotionService(
            IPupilFactory pupilFactory)
        {
            this.pupilFactory = pupilFactory;
        }

        public List<Pupil> GeneratePromotionResults(List<ExamResult> examResults)
        {
            var pupils = examResults
                .GroupBy(x => x.PupilId)
                .Select(y => this.pupilFactory.Create(y.ToList()))
                .ToList();

            return pupils;
        }
    }
}
