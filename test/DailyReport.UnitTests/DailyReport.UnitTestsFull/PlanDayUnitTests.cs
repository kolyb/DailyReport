using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class PlanDayUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenPlanDayReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var planDayMock = new Mock<IRepository<PlanDay>>();

            planDayMock.Setup(m => m.GetAll()).Returns(new List<PlanDay>
            {
                new PlanDay { Id = 2, Day = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ; 

            var planDays = new PlanDayService(planDayMock.Object);

            PlanDayDTO? newPlanDay = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await planDays.CreateAsync(newPlanDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a plan day"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenPlanDayReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var planDayMock = new Mock<IRepository<PlanDay>>();

            planDayMock.Setup(m => m.GetAll()).Returns(new List<PlanDay>
            {
                new PlanDay { Id = 2, Day = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ;

            var planDays = new PlanDayService(planDayMock.Object);

            PlanDayDTO? newPlanDay = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await planDays.DeleteAsync(newPlanDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a day"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenIdPlanDayEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var planDayMock = new Mock<IRepository<PlanDay>>();

            planDayMock.Setup(m => m.GetAll()).Returns(new List<PlanDay>
            {
                new PlanDay { Id = 2, Day = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ;

            var planDays = new PlanDayService(planDayMock.Object);

            PlanDayDTO? newPlanDay = new PlanDayDTO
            {
                Id = 0,
                Day = new DateTime(2023, 12, 11),
                UserName = "cat@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await planDays.DeleteAsync(newPlanDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenPlanDayReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var planDayMock = new Mock<IRepository<PlanDay>>();

            planDayMock.Setup(m => m.GetAll()).Returns(new List<PlanDay>
            {
                new PlanDay { Id = 2, Day = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ;

            var planDays = new PlanDayService(planDayMock.Object);

            PlanDayDTO? newPlanDay = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await planDays.UpdateAsync(newPlanDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not update a day"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenIdPlanDayEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var planDayMock = new Mock<IRepository<PlanDay>>();

            planDayMock.Setup(m => m.GetAll()).Returns(new List<PlanDay>
            {
                new PlanDay { Id = 2, Day = new DateTime(2024, 11, 11), UserName = "gg@mail.ru" },
            }); ;

            var planDays = new PlanDayService(planDayMock.Object);

            PlanDayDTO? newPlanDay = new PlanDayDTO
            {
                Id = 0,
                Day = new DateTime(2023, 12, 11),
                UserName = "cat@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await planDays.UpdateAsync(newPlanDay);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }
    }
}
