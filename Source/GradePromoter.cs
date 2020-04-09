namespace Grade.Promoter
{
    using Grade.Promoter.Services;

    public class GradePromoter
    {
        private readonly IFileService fileService;
        private readonly IPupilsService pupilsService;

        public GradePromoter(
          IFileService fileService,
          IPupilsService pupilsService)
        {
            this.fileService = fileService;
            this.pupilsService = pupilsService;
        }

        public void CalculatePromotions(string input, string output)
        {
            // Read csv file and transform them into ExamResult objects
            var examResults = this.fileService.ParseExamResultsFromCsv(input);

            // Process the exam results data
            var pupils = this.pupilsService.GeneratePromotionResults(examResults);

            // Write the promotion results to a file
            this.fileService.WritePromotionResults(pupils, output);
        }
    }
}