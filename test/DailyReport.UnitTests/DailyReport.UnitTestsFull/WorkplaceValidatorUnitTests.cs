using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class WorkplaceValidatorUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenWorkplaceExists_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 2, Description = "ГЦГП", AdressCity = "Гомель",
                    AdressStreet = "Советская", AdressHouse = "44", UserIdentityEmail = "gol@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = new WorkplaceDTO
            {
                Description = "ГЦГП",
                AdressCity = "Гомель",
                AdressStreet = "Советская",
                AdressHouse = "44",
                UserIdentityEmail = "gol@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.CreateAsync(newWorkplace);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Workplcace '{newWorkplace.Description} {newWorkplace.AdressCity}, {newWorkplace.AdressStreet}, " +
                    $"{newWorkplace.AdressHouse}' already exists"));
            });
        }

        [Test]
        public async Task GetByIdAsync_WithoutWorkplaceCanNotDeleteAndEdit_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 1, Description = "Without workplace", AdressCity = "Without workplace",
                    AdressStreet = "Without workplace", AdressHouse = "Without workplace", UserIdentityEmail = "gol@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = new WorkplaceDTO
            {
                Id = 1,
                Description = "Without workplace",
                AdressCity = "Without workplace",
                AdressStreet = "Without workplace",
                AdressHouse = "Without workplace",
                UserIdentityEmail = "gol@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.GetByIdAsync(newWorkplace.Id);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete and edit Without workplace"));
            });
        }
    }
}
