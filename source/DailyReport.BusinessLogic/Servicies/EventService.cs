using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class EventService : IService<EventDTO>
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task CreateAsync(EventDTO item)
        {
            if (item == null)
            {   
                //
                throw new ArgumentNullException("item");
            }
            Event @event = EventMapper.FromDTO(item);
            await _eventRepository.CreateAsync(@event);
        }

        public async Task DeleteAsync(EventDTO item)
        {
            Event @event = EventMapper.FromDTO(item);
            await _eventRepository.DeleteAsync(@event);
        }

        public void Dispose()
        {
            _eventRepository.Dispose();
        }

        public IList<EventDTO> GetAll()
        {
            List<Event> events = _eventRepository.GetAll().ToList();
            List<EventDTO> list = EventMapper.ToDTO(events);
            return list;
        }

        public async Task<EventDTO> GetByIdAsync(int id)
        {
            var @event = await _eventRepository.GetByIdAsync(id);
            EventDTO eventDTO = EventMapper.ToDTO(@event);
            return eventDTO;
        }

        public async Task UpdateAsync(EventDTO item)
        {
            Event @event = EventMapper.FromDTO(item);
            await _eventRepository.UpdateAsync(@event);
        }
    }
}
