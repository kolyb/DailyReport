using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public static class PersonMapper
    {
        public static Person FromDTO(PersonDTO item)
        {
            Person person = new Person
            {
                Id = item.Id,
                Birthday = item.Birthday,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                WorkLocationId = item.WorkLocationId,
                PositionId = item.PositionId,
                //UserIdentityId = item.UserIdentityId,
                PhoneNumber = item.PhoneNumber,
            };
            return person;
        }

        public static PersonDTO ToDTO(Person item)
        {
            PersonDTO personDTO = new PersonDTO
            {
                Id = item.Id,
                Birthday = item.Birthday,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                WorkLocationId = item.WorkLocationId,
                PositionId = item.PositionId,
                //UserIdentityId = item.UserIdentityId,
                PhoneNumber = item.PhoneNumber,
            };
            return personDTO;
        }

        public static List<PersonDTO> ToDTO(List<Person> list)
        {
            List<PersonDTO> personDTOs = new List<PersonDTO>();
            foreach (var item in list)
            {
                personDTOs.Add(new PersonDTO
                {
                    Id = item.Id,
                    Birthday = item.Birthday,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName,
                    WorkLocationId = item.WorkLocationId,
                    PositionId = item.PositionId,
                    //UserIdentityId = item.UserIdentityId,
                    PhoneNumber = item.PhoneNumber,
                });
            }
            return personDTOs;
        }
    }
}
