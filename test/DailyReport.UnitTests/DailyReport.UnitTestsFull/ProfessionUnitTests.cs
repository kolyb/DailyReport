using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class ProfessionUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenProfessionReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 23, Description = "Хирург" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.CreateAsync(newProfession);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a profession"));
            });
        }

        [Test]
        public async Task CreateAsync()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 1, Description = "ВОП" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = new ProfessionDTO { Description = "Невролог" };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.CreateAsync(newProfession);

                // Assert
                var result = testAction;
                Assert.Pass("Successfully", result);
            });
        }

        [Test]
        public async Task DeleteAsync_WhenProfessionReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 5, Description = "ЛОР" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.DeleteAsync(newProfession);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a profession"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenIdProfessionEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 5, Description = "ЛОР" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = new ProfessionDTO { Id = 0, Description = "ВОП" };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.DeleteAsync(newProfession);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task GetByIdAsync_WhenIdProfessionEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 5, Description = "ЛОР" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = new ProfessionDTO { Id = 0, Description = "ВОП" };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.GetByIdAsync(newProfession.Id);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenProfessionReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 5, Description = "ЛОР" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.UpdateAsync(newProfession);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not update a profession"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenIdProfessionEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 5, Description = "ЛОР" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = new ProfessionDTO { Id = 0, Description = "ВОП" };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.UpdateAsync(newProfession);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }
    }
}
