namespace Grade.Promotions.Test.UnitTest
{
    using System;
    using System.Collections.Generic;
    using Grade.Promotions.Services;
    using Grade.Promotions.ViewModels;
    using Moq;
    using Xunit;

    public class GradePromotionsTest : IDisposable
    {
        private readonly Mock<IFileService> fileServiceMock;
        private readonly GradePromotionsService service;

        public GradePromotionsTest()
        {
            this.fileServiceMock = new Mock<IFileService>(MockBehavior.Strict);
            this.service = new GradePromotionsService(this.fileServiceMock.Object);
        }

        [Fact]
        public void GetPromotionResults_ValidInputString_ReadsFile()
        {
            var input = "input.txt";
            var examResults = new List<ExamResult>()
            {
                new ExamResult()
                {
                    Grade = "grade",
                    Subject = "subject",
                    PupilName = "pupilName",
                },
            };

            this.fileServiceMock
                .Setup(x => x.ParseExamResultsFromCsv(It.IsAny<string>()))
                .Returns(examResults);

            var promotionResults = this.service.GetPromotionResults(input);
        }

        public void Dispose() =>

            Mock.VerifyAll(this.fileServiceMock);
    }
}
