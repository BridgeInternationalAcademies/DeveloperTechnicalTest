namespace Grade.Promoter.Test.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Grade.Promoter.Factories;
    using Grade.Promoter.Models;
    using Grade.Promoter.Services;
    using Grade.Promoter.ViewModels;
    using Moq;
    using Shouldly;
    using Xunit;

    public class PromotionServiceTests : IDisposable
    {
        private readonly PromotionService promotionService;
        private readonly Mock<IPupilFactory> pupilFactoryMock;

        public PromotionServiceTests()
        {
            this.pupilFactoryMock = new Mock<IPupilFactory>(MockBehavior.Strict);
            this.promotionService = new PromotionService(this.pupilFactoryMock.Object);
        }

        public void Dispose()
        {
            Mock.VerifyAll(this.pupilFactoryMock);
        }

        [Fact]
        public void GeneratePromotionResults_ExamResultsForSinglePupil_ReturnsSinglePupil()
        {
            var pupilId = 1;
            var examResults = new List<ExamResult>
            {
                new ExamResult
                {
                    PupilId = pupilId,
                },
            };
            var mockPupil = new Pupil
            {
                PupilId = pupilId,
            };

            this.pupilFactoryMock
                .Setup(x => x.Create(examResults))
                .Returns(mockPupil);

            var pupils = this.promotionService.GeneratePromotionResults(examResults);

            pupils.Count().ShouldBe(1);
            pupils.Single().ShouldBe(mockPupil);
        }

        [Fact]
        public void GeneratePromotionResults_ExamResultsForTwoPupil_ReturnsTwoPupil()
        {
            var pupilId1 = 1;
            var pupilId2 = 2;

            var examResults = new List<ExamResult>
            {
                new ExamResult
                {
                    PupilId = pupilId1,
                },
                new ExamResult
                {
                    PupilId = pupilId2,
                },
            };
            var mockPupil1 = new Pupil
            {
                PupilId = pupilId1,
            };
            var mockPupil2 = new Pupil
            {
                PupilId = pupilId2,
            };

            this.pupilFactoryMock
                .Setup(x => x.Create(It.Is<List<ExamResult>>(y => y.All(z => z.PupilId == 1))))
                .Returns(mockPupil1);

            this.pupilFactoryMock
                 .Setup(x => x.Create(It.Is<List<ExamResult>>(y => y.All(z => z.PupilId == 2))))
                 .Returns(mockPupil2);

            var pupils = this.promotionService.GeneratePromotionResults(examResults);

            pupils.Count().ShouldBe(2);
            pupils.Contains(mockPupil1);
            pupils.Contains(mockPupil2);
        }
    }
}
