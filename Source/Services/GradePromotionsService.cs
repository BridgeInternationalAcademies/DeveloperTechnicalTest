namespace Grade.Promotions.Services
{
    using System.Collections.Generic;
    using Grade.Promotions.ViewModels;

    public class GradePromotionsService : IGradePromotionsService
    {
        private readonly IFileService fileService;

        public GradePromotionsService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public List<PromotionResult> GetPromotionResults(string input)
        {
            var examResults = this.fileService.ParseExamResultsFromCsv(input);

            // TODO
            throw new System.NotImplementedException();
        }
    }
}
