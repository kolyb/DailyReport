﻿using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class ReportUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenReportReferenceNotSet_ShouldThrowException()
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

            ReportDTO? newReport = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.CreateAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a report"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenReportReferenceNotSet_ShouldThrowException()
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

            ReportDTO? newReport = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.DeleteAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a report"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenIdReportEqulsOrLessZero_ShouldThrowException()
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
                Id = 0,
                PersonId = 1,
                ReportDayId = 1,
                StartTime = new TimeSpan(09, 00, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.DeleteAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task GetByIdAsync_WhenIdReportEqulsOrLessZero_ShouldThrowException()
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
                Id = 0,
                PersonId = 1,
                ReportDayId = 1,
                StartTime = new TimeSpan(09, 00, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.GetByIdAsync(newReport.Id);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenReportReferenceNotSet_ShouldThrowException()
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

            ReportDTO? newReport = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.UpdateAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not update a report"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenIdReportEqulsOrLessZero_ShouldThrowException()
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
                Id = 0,
                PersonId = 1,
                ReportDayId = 1,
                StartTime = new TimeSpan(09, 00, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await reports.UpdateAsync(newReport);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }
    }
}
