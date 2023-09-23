using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Mappers
{
    public static class EventMapper
    {
        public static Event FromDTO(EventDTO item)
        {
            Event @event = new Event
            {
                Id = item.Id,
                Description = item.Description,
                EventTime = item.EventTime,
            };
            return @event;
        }

        public static EventDTO ToDTO(Event item)
        {
            EventDTO eventDTO = new EventDTO
            {
                Id = item.Id,
                Description = item.Description,
                EventTime = item.EventTime,
            };
            return eventDTO;
        }

        public static List<EventDTO> ToDTO(List<Event> list)
        {
            List<EventDTO> eventDTOs = new List<EventDTO>();
            foreach (var item in list)
            {
                eventDTOs.Add(new EventDTO
                {
                    Id = item.Id,
                    Description = item.Description,
                    EventTime = item.EventTime,
                });
            }
            return eventDTOs;
        }
    }
}
