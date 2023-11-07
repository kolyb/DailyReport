using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class ReportValidatorUnitTests
    {
        [Test]
        public async Task CreateAsync_PersonExistsInReport_ShouldThrowException()
        {
            // Arrange
            var reportMock = new Mock<IRepository<Report>>();

            reportMock.Setup(m => m.GetAll()).Returns(new List<Report>
            {
                new Report
                {
                    Id = 1,
                    PersonId = 1,
                    ReportDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            });

            var reports = new ReportService(reportMock.Object);

            ReportDTO? newReport = new ReportDTO
            {
                Id = 2,
                PersonId = 1,
                ReportDayId = 1,
                StartTime = new TimeSpan(09, 00, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.CreateAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"This Person already exists in the report"));
            });
        }

        [Test]
        public async Task CreateAsync_StartTimeExistsInReport_ShouldThrowException()
        {
            // Arrange
            var reportMock = new Mock<IRepository<Report>>();

            reportMock.Setup(m => m.GetAll()).Returns(new List<Report>
            {
                new Report
                {
                    Id = 1,
                    PersonId = 1,
                    ReportDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            });

            var reports = new ReportService(reportMock.Object);

            ReportDTO? newReport = new ReportDTO
            {
                Id = 2,
                PersonId = 2,
                ReportDayId = 1,
                StartTime = new TimeSpan(09, 00, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.CreateAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Start Time'{newReport.StartTime}' already exists in the report"));
            });
        }

        [Test]
        public async Task CreateAsync_FinishTimeExistsInReport_ShouldThrowException()
        {
            // Arrange
            var reportMock = new Mock<IRepository<Report>>();

            reportMock.Setup(m => m.GetAll()).Returns(new List<Report>
            {
                new Report
                {
                    Id = 1,
                    PersonId = 1,
                    ReportDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            });

            var reports = new ReportService(reportMock.Object);

            ReportDTO? newReport = new ReportDTO
            {
                Id = 2,
                PersonId = 2,
                ReportDayId = 1,
                StartTime = new TimeSpan(09, 30, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.CreateAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Finish Time'{newReport.FinishTime}' already exists in the report"));
            });
        }

        [Test]
        public async Task CreateAsync_StartTimeCorrect_ShouldThrowException()
        {
            // Arrange
            var reportMock = new Mock<IRepository<Report>>();

            reportMock.Setup(m => m.GetAll()).Returns(new List<Report>
            {
                new Report
                {
                    Id = 1,
                    PersonId = 1,
                    ReportDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            });

            var reports = new ReportService(reportMock.Object);

            ReportDTO? newReport = new ReportDTO
            {
                Id = 2,
                PersonId = 2,
                ReportDayId = 1,
                StartTime = new TimeSpan(09, 30, 00),
                FinishTime = new TimeSpan(09, 40, 00),
                IntervalTime = new TimeSpan(00, 10, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.CreateAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Start Time'{newReport.StartTime}' is not correct"));
            });
        }
    }
}
