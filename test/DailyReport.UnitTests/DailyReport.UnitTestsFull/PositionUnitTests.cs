using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using ValidationException = DailyReport.BusinessLogic.Exceptions.ExceptionValidator.ValidationException;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class PositionUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenPositionReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var positionMock = new Mock<IRepository<Position>>();

            positionMock.Setup(m => m.GetAll()).Returns(new List<Position>
            {
                new Position { Id = 2, Description = "Интерн" },
            });

            var positions = new PositionService(positionMock.Object);

            PositionDTO? newPosition = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await positions.CreateAsync(newPosition);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a position"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenPositionReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var positionMock = new Mock<IRepository<Position>>();

            positionMock.Setup(m => m.GetAll()).Returns(new List<Position>
            {
                new Position { Id = 12, Description = "Врач" },
            });

            var positions = new PositionService(positionMock.Object);

            PositionDTO? newPosition = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await positions.DeleteAsync(newPosition);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a position"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenPositionReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var positionMock = new Mock<IRepository<Position>>();

            positionMock.Setup(m => m.GetAll()).Returns(new List<Position>
            {
                new Position { Id = 1, Description = "Главный врач" },
            });

            var positions = new PositionService(positionMock.Object);

            PositionDTO? newPosition = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await positions.UpdateAsync(newPosition);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not update a position"));
            });
        }

    }
}
