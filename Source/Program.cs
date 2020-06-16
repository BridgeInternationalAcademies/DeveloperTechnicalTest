namespace GradePromoter.Services
{
    using System;
    using Grade.Promotions.Services;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        private static void Main(string[] args)
        {
            var input = "ExamResults.csv";
            Console.WriteLine($"Reading exam results data from {input}");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<IGradePromotionsService, GradePromotionsService>()
                .BuildServiceProvider();

            Console.WriteLine($"Processing...");
            var gradePromotionsService = serviceProvider.GetService<IGradePromotionsService>();

            var promotionResults = gradePromotionsService.GetPromotionResults(input);

            foreach (var result in promotionResults)
            {
                Console.WriteLine($"Pupil Id: {result.PupilId}, Promoted: {result.IsPromoted}");
            }
        }
    }
}
