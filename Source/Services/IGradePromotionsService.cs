namespace Grade.Promotions.Services
{
    using System.Collections.Generic;
    using Grade.Promotions.ViewModels;

    public interface IGradePromotionsService
    {
        List<PromotionResult> GetPromotionResults(string input);
    }
}
