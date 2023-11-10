using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class ReportDayValidatorUnitTests
    {
        [Test]
        public async Task CreateAsync_ReportDayExists_ShouldThrowException()
        {
            // Arrange
            var reportDayMock = new Mock<IRepository<ReportDay>>();

            reportDayMock.Setup(m => m.GetAll()).Returns(new List<ReportDay>
            {
                new ReportDay { Id = 2, RecordDay = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ;

            var reportDays = new ReportDayService(reportDayMock.Object);

            ReportDayDTO? newReportDay = new ReportDayDTO
            {
                RecordDay = new DateTime(2024, 11, 11),
                UserName = "gg@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reportDays.CreateAsync(newReportDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Day '{newReportDay.RecordDay}' already exists"));
            });
        }
    }
}
