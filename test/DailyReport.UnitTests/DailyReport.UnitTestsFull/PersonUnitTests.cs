using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class PersonUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenPersonReferenceNotSet_ShouldThrowException()
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

            PersonDTO? newPerson = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.CreateAsync(newPerson);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not create a person"));
            });
        }

        [Test]
        public async Task CreateAsync()
        {
            // Arrange
            var personMock = new Mock<IRepository<Person>>();

            personMock.Setup(m => m.GetAll()).Returns(new List<Person>
            {
                new Person { Id = 2,
                    FirstName = "Виктор",
                    MiddleName = "Викторович",
                    LastName = "Иванов",
                    WorkplaceId = 2,
                    PositionId = 2,
                    ProfessionId = 1},
            });

            var persons = new PersonService(personMock.Object);

            PersonDTO? newPerson = new PersonDTO {
                FirstName = "Aлександр",
                MiddleName = "Викторович",
                LastName = "Петров",
                WorkplaceId = 3,
                PositionId = 2,
                ProfessionId = 1
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.CreateAsync(newPerson);

                // Assert
                var result = testAction;
                Assert.Pass("Successfully", result);
            });
        }

        [Test]
        public async Task DeleteAsync_WhenPersonReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var personMock = new Mock<IRepository<Person>>();

            personMock.Setup(m => m.GetAll()).Returns(new List<Person>
            {
                new Person
                {
                    Id = 10,
                    FirstName = "Петр",
                    MiddleName = "Викторович",
                    LastName = "Смирнов",
                    WorkplaceId = 1,
                    PositionId = 1,
                    ProfessionId = 1,
                },
            });

            var persons = new PersonService(personMock.Object);

            PersonDTO? newPerson = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.DeleteAsync(newPerson);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not delete a person"));
            });
        }

        [Test]
        public async Task DeleteAsync_WhenIdPersonEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var personMock = new Mock<IRepository<Person>>();

            personMock.Setup(m => m.GetAll()).Returns(new List<Person>
            {
                new Person
                {
                    Id = 10,
                    FirstName = "Петр",
                    MiddleName = "Викторович",
                    LastName = "Смирнов",
                    WorkplaceId = 1,
                    PositionId = 1,
                    ProfessionId = 1,
                },
            });

            var persons = new PersonService(personMock.Object);

            PersonDTO? newPerson = new PersonDTO
            {
                Id = 0,
                FirstName = "Петр",
                MiddleName = "Викторович",
                LastName = "Смирнов",
                WorkplaceId = 1,
                PositionId = 1,
                ProfessionId = 1,
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.DeleteAsync(newPerson);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task GetByIdAsync_WhenIdPersonEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var personMock = new Mock<IRepository<Person>>();

            personMock.Setup(m => m.GetAll()).Returns(new List<Person>
            {
                new Person
                {
                    Id = 10,
                    FirstName = "Петр",
                    MiddleName = "Викторович",
                    LastName = "Смирнов",
                    WorkplaceId = 1,
                    PositionId = 1,
                    ProfessionId = 1,
                },
            });

            var persons = new PersonService(personMock.Object);

            PersonDTO? newPerson = new PersonDTO
            {
                Id = 0,
                FirstName = "Петр",
                MiddleName = "Викторович",
                LastName = "Смирнов",
                WorkplaceId = 1,
                PositionId = 1,
                ProfessionId = 1,
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.GetByIdAsync(newPerson.Id);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenPersonReferenceNotSet_ShouldThrowException()
        {
            // Arrange
            var personMock = new Mock<IRepository<Person>>();

            personMock.Setup(m => m.GetAll()).Returns(new List<Person>
            {
                new Person
                {
                    Id = 10,
                    FirstName = "Петр",
                    MiddleName = "Викторович",
                    LastName = "Смирнов",
                    WorkplaceId = 1,
                    PositionId = 1,
                    ProfessionId = 1,
                },
            });

            var persons = new PersonService(personMock.Object);

            PersonDTO? newPerson = null;

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.UpdateAsync(newPerson);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("Can not update a person"));
            });
        }

        [Test]
        public async Task UpdateAsync_WhenIdPersonEqulsOrLessZero_ShouldThrowException()
        {
            // Arrange
            var personMock = new Mock<IRepository<Person>>();

            personMock.Setup(m => m.GetAll()).Returns(new List<Person>
            {
                new Person
                {
                    Id = 10,
                    FirstName = "Петр",
                    MiddleName = "Викторович",
                    LastName = "Смирнов",
                    WorkplaceId = 1,
                    PositionId = 1,
                    ProfessionId = 1,
                },
            });

            var persons = new PersonService(personMock.Object);

            PersonDTO? newPerson = new PersonDTO
            {
                Id = 0,
                FirstName = "Петр",
                MiddleName = "Викторович",
                LastName = "Смирнов",
                WorkplaceId = 1,
                PositionId = 1,
                ProfessionId = 1,
            };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await persons.UpdateAsync(newPerson);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo("It is impossible"));
            });
        }
    }
}
