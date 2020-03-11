namespace Grade.Promotions.Services
{
    public class GradePromotionsService : IGradePromotionsService
    {
        private readonly IFileService fileService;

        public GradePromotionsService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void Calculate(string input)
        {
            var examResults = this.fileService.ParseExamResultsFromCsv(input);

            // TODO
            throw new System.NotImplementedException();
        }
    }
}
