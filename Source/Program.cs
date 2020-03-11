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
            gradePromotionsService.Calculate(input);
        }
    }
}
