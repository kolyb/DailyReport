using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.BusinessLogic.Servicies
{
    public class PersonService : IService<PersonDTO>
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreateAsync(PersonDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not create a person");
            }
            Person person = PersonMapper.FromDTO(item);
            await _personRepository.CreateAsync(person);
        }

        public async Task DeleteAsync(PersonDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not delete a person");
            }
            if (item.Id <= 0)
            {
                throw new ValidationException("Id should be greater than 0");
            }

            Person person = PersonMapper.FromDTO(item);
            await _personRepository.DeleteAsync(person);
        }

        public void Dispose()
        {
            _personRepository.Dispose();
        }

        public IList<PersonDTO> GetAll()
        {
            List<Person> persons = _personRepository.GetAll().ToList();
            List<PersonDTO> list = PersonMapper.ToDTO(persons);
            return list;
        }

        public async Task<PersonDTO> GetByIdAsync(int? id)
        {   
            var person = await _personRepository.GetByIdAsync(id);
            PersonDTO personDTO = PersonMapper.ToDTO(person);
            return personDTO;
        }

        public async Task UpdateAsync(PersonDTO item)
        {
            Person person = PersonMapper.FromDTO(item);
            await _personRepository.UpdateAsync(person);
        }
    }
}
