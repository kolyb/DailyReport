using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class ReportDayUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenReportDayReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var reportDayMock = new Mock<IRepository<ReportDay>>();

            reportDayMock.Setup(m => m.GetAll()).Returns(new List<ReportDay>
            {
                new ReportDay { Id = 2, RecordDay = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ;

            var reportDays = new ReportDayService(reportDayMock.Object);

            ReportDayDTO? newReportDay = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reportDays.CreateAsync(newReportDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a report day"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenReportDayReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var reportDayMock = new Mock<IRepository<ReportDay>>();

            reportDayMock.Setup(m => m.GetAll()).Returns(new List<ReportDay>
            {
                new ReportDay { Id = 2, RecordDay = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ;

            var reportDays = new ReportDayService(reportDayMock.Object);

            ReportDayDTO? newReportDay = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reportDays.DeleteAsync(newReportDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a day"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenIdReportDayEqulsOrLessZero_ShouldThrowException()
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
                Id = 0,
                RecordDay = new DateTime(2024, 11, 11),
                UserName = "gg@mail.ru",
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reportDays.DeleteAsync(newReportDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }
    }
}
