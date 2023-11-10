using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class WorkplaceUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenWorkplaceReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 2, Description = "ГЦГП", AdressCity = "Гомель", 
                    AdressStreet = "Советская", AdressHouse = "44", UserIdentityEmail = "gol@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.CreateAsync(newWorkplace);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a workplace"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenWorkplaceReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 12, Description = "Филиал 1", AdressCity = "Гомель",
                    AdressStreet = "Пушкина", AdressHouse = "1", UserIdentityEmail = "dark@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.DeleteAsync(newWorkplace);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a workplace"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenIdWorkplaceEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 11, Description = "Филиал 10", AdressCity = "Гомель",
                    AdressStreet = "Юбилейная", AdressHouse = "21", UserIdentityEmail = "dark@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = new WorkplaceDTO
            {
                Id = 0,
                Description = "Филиал 2",
                AdressCity = "Гомель",
                AdressStreet = "Спортивная",
                AdressHouse = "129",
                UserIdentityEmail = "dark@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.DeleteAsync(newWorkplace);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task GetByIdAsync_WhenIdWorkplaceEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 11, Description = "Филиал 10", AdressCity = "Гомель",
                    AdressStreet = "Юбилейная", AdressHouse = "21", UserIdentityEmail = "dark@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = new WorkplaceDTO
            {   
                Id = 0,
                Description = "Филиал 2",
                AdressCity = "Гомель",
                AdressStreet = "Спортивная",
                AdressHouse = "129",
                UserIdentityEmail = "dark@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.GetByIdAsync(newWorkplace.Id);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not use"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenWorkplaceReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 12, Description = "Филиал 1", AdressCity = "Гомель",
                    AdressStreet = "Пушкина", AdressHouse = "1", UserIdentityEmail = "dark@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.UpdateAsync(newWorkplace);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not update a workplace"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenIdWorkplaceEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var workplaceMock = new Mock<IRepository<Workplace>>();

            workplaceMock.Setup(m => m.GetAll()).Returns(new List<Workplace>
            {
                new Workplace { Id = 11, Description = "Филиал 10", AdressCity = "Гомель",
                    AdressStreet = "Юбилейная", AdressHouse = "21", UserIdentityEmail = "dark@mail.ru" },
            });

            var workplaces = new WorkplaceService(workplaceMock.Object);

            WorkplaceDTO? newWorkplace = new WorkplaceDTO
            {
                Id = 0,
                Description = "Филиал 2",
                AdressCity = "Гомель",
                AdressStreet = "Спортивная",
                AdressHouse = "129",
                UserIdentityEmail = "dark@mail.ru"
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await workplaces.UpdateAsync(newWorkplace);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }
    }
}
