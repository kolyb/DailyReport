using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class PlanValidatorUnitTests
    {
        [Test]
        public async Task CreateAsync_PersonExistsInPlan_ShouldThrowException()
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

            PlanDTO? newPlan = new PlanDTO
            {
                Id = 2,
                PersonId = 1,
                PlanDayId = 1,
                StartTime = new TimeSpan(09, 00, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.CreateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"This Person already exists in the plan"));
            });
        }

        [Test]
        public async Task CreateAsync_StartTimeExistsInPlan_ShouldThrowException()
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

            PlanDTO? newPlan = new PlanDTO
            {
                Id = 2,
                PersonId = 2,
                PlanDayId = 1,
                StartTime = new TimeSpan(09, 00, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.CreateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Start Time'{newPlan.StartTime}' already exists in the plan"));
            });
        }

        [Test]
        public async Task CreateAsync_FinishTimeExistsInPlan_ShouldThrowException()
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

            PlanDTO? newPlan = new PlanDTO
            {
                Id = 2,
                PersonId = 2,
                PlanDayId = 1,
                StartTime = new TimeSpan(09, 30, 00),
                FinishTime = new TimeSpan(10, 00, 00),
                IntervalTime = new TimeSpan(01, 00, 00)
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.CreateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Finish Time'{newPlan.FinishTime}' already exists in the plan"));
            });
        }

        [Test]
        public async Task CreateAsync_StartTimeCorrect_ShouldThrowException()
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

            PlanDTO? newPlan = new PlanDTO
            {
                Id = 2,
                PersonId = 2,
                PlanDayId = 1,
                StartTime = new TimeSpan(09, 30, 00),
                FinishTime = new TimeSpan(09, 40, 00),
                IntervalTime = new TimeSpan(00, 10, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.CreateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Start Time'{newPlan.StartTime}' is not correct"));
            });
        }

        [Test]
        public async Task CreateAsync_FinishTimeEqualStartTime_ShouldThrowException()
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

            PlanDTO? newPlan = new PlanDTO
            {
                Id = 2,
                PersonId = 2,
                PlanDayId = 1,
                StartTime = new TimeSpan(10, 30, 00),
                FinishTime = new TimeSpan(10, 30, 00),
                IntervalTime = new TimeSpan(00, 00, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.CreateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Finish Time'{newPlan.FinishTime}' is not correct"));
            });
        }

        [Test]
        public async Task CreateAsync_FinishTimeLessThanlStartTime_ShouldThrowException()
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

            PlanDTO? newPlan = new PlanDTO
            {
                Id = 2,
                PersonId = 2,
                PlanDayId = 1,
                StartTime = new TimeSpan(10, 40, 00),
                FinishTime = new TimeSpan(10, 30, 00),
                IntervalTime = new TimeSpan(00, 10, 00),
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await plans.CreateAsync(newPlan);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Finish Time'{newPlan.FinishTime}' is not correct"));
            });
        }
    }       
        
}
