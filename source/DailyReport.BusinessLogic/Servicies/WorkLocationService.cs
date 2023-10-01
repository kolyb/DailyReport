using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class WorkLocationService : IService<WorkLocationDTO>
    {
        private readonly IRepository<WorkLocation> _workLocationRepository;

        public WorkLocationService(IRepository<WorkLocation> workLocationRepository)
        {
            _workLocationRepository = workLocationRepository;
        }

        public async Task CreateAsync(WorkLocationDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            WorkLocation workLocation = WorkLocationMapper.FromDTO(item);
            await _workLocationRepository.CreateAsync(workLocation);
        }

        public async Task DeleteAsync(WorkLocationDTO item)
        {
            WorkLocation workLocation = WorkLocationMapper.FromDTO(item);
            await _workLocationRepository.DeleteAsync(workLocation);
        }

        public void Dispose()
        {
            _workLocationRepository.Dispose();
        }

        public IList<WorkLocationDTO> GetAll()
        {
            List<WorkLocation> workLocations = _workLocationRepository.GetAll().ToList();
            List<WorkLocationDTO> list = WorkLocationMapper.ToDTO(workLocations);
            return list;
        }

        public async Task<WorkLocationDTO> GetByIdAsync(int id)
        {
            var workLocation = await _workLocationRepository.GetByIdAsync(id);
            WorkLocationDTO workLocationDTO = WorkLocationMapper.ToDTO(workLocation);
            return workLocationDTO;
        }

        public async Task UpdateAsync(WorkLocationDTO item)
        {
            WorkLocation workLocation = WorkLocationMapper.FromDTO(item);
            await _workLocationRepository.UpdateAsync(workLocation);
        }
    }
}
