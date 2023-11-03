using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.Servicies;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.UnitTests.DailyReport.UnitTestsFull
{
    [TestFixture]
    public class ProfessionValidatorUnitTests
    {
        [Test]
        public async Task CreateAsync_WhenProfessionAlreadyExists_ShouldThrowException()
        {
            // Arrange
            var professionMock = new Mock<IRepository<Profession>>();

            professionMock.Setup(m => m.GetAll()).Returns(new List<Profession>
            {
                new Profession { Id = 23, Description = "Хирург" },
            });

            var professions = new ProfessionService(professionMock.Object);

            ProfessionDTO? newProfession = new ProfessionDTO { Description = "Хирург" };

            // Act
            await Task.Run(() =>
            {
                AsyncTestDelegate testAction = async () => await professions.CreateAsync(newProfession);

                // Assert
                var ex = Assert.ThrowsAsync<ValidationException>(testAction);
                Assert.That(ex.Message, Is.EqualTo($"Profession '{newProfession.Description}' already exists"));
            });
        }

    }
}
