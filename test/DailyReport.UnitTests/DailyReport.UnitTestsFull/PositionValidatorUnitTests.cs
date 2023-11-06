using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class PositionValidatorUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenPositionAlreadyExists_ShouldThrowException()
        {
            // Arrange
            var positionMock = new Mock<IRepository<Position>>();

            positionMock.Setup(m => m.GetAll()).Returns(new List<Position>
            {
                new Position { Id = 2, Description = "Интерн" },
            });

            var positions = new PositionService(positionMock.Object);

            PositionDTO? newPosition = new PositionDTO { Description = "Интерн" };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await positions.CreateAsync(newPosition);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Position '{newPosition.Description}' already exists"));
            });
        }
    }
}
