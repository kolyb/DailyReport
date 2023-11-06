using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class PersonValidatorUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenPersonAlreadyExists_ShouldThrowException()
        {
            // Arrange
            var personMock = new Mock<IRepository<Person>>();

            personMock.Setup(m => m.GetAll()).Returns(new List<Person>
            {
                new Person
                {
                    Id = 2,
                    FirstName = "Виктор",
                    MiddleName = "Викторович",
                    LastName = "Иванов",
                    WorkplaceId = 2,
                    PositionId = 2,
                    ProfessionId = 1,
                },
            });

            var persons = new PersonService(personMock.Object);

            PersonDTO? newPerson = new PersonDTO
            {
                FirstName = "Виктор",
                MiddleName = "Викторович",
                LastName = "Иванов",
                WorkplaceId = 2,
                PositionId = 2,
                ProfessionId = 1,
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.CreateAsync(newPerson);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Person '{newPerson.LastName} {newPerson.MiddleName} {newPerson.FirstName}' already exists"));
            });
        }
    }
}
