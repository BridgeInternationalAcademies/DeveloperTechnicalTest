namespace Grade.Promoter.Test.UnitTest
{
    using Grade.Promoter.Services;
    using Shouldly;
    using Xunit;

    public class PromotionServiceTests
    {
        private readonly PromotionService promotionService;

        public PromotionServiceTests()
        {
            this.promotionService = new PromotionService();
        }

        [Fact]
        public void OneIsOne() {
            1.ShouldBe(1);
        }
    }

}
