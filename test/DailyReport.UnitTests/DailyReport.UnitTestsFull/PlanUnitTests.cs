using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class PlanUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenPlanReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var planMock = new Mock<IRepository<Plan>>();

            planMock.Setup(m => m.GetAll()).Returns(new List<Plan>
            {
                new Plan
                {
                    Id = 1,
                    PersonId = 1,
                    PlanDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            }) ;

            var plans = new PlanService(planMock.Object);

            PlanDTO? newPlan = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.CreateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a plan"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenPlanReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var planMock = new Mock<IRepository<Plan>>();

            planMock.Setup(m => m.GetAll()).Returns(new List<Plan>
            {
                new Plan
                {
                    Id = 1,
                    PersonId = 1,
                    PlanDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            });

            var plans = new PlanService(planMock.Object);

            PlanDTO? newPlan = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.DeleteAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a plan"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenIdPlanEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var planMock = new Mock<IRepository<Plan>>();

            planMock.Setup(m => m.GetAll()).Returns(new List<Plan>
            {
                new Plan { 
                    Id = 1,
                    PersonId = 1,
                    PlanDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            });

            var plans = new PlanService(planMock.Object);

            PlanDTO? newPlan = new PlanDTO {
                Id = 0,
                PersonId = 1,
                PlanDayId = 1,
                StartTime = new TimeSpan(11, 00, 00),
                FinishTime = new TimeSpan(12, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.DeleteAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenPlanReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var planMock = new Mock<IRepository<Plan>>();

            planMock.Setup(m => m.GetAll()).Returns(new List<Plan>
            {
                new Plan
                {
                    Id = 1,
                    PersonId = 1,
                    PlanDayId = 1,
                    StartTime = new TimeSpan(09,00,00),
                    FinishTime = new TimeSpan(10,00,00),
                    IntervalTime = new TimeSpan(01,00,00),
                },
            });

            var plans = new PlanService(planMock.Object);

            PlanDTO? newPlan = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.UpdateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not update a plan"));
            });
        }
    }
}
