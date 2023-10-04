using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;

namespace DailyReport.BusinessLogic.Servicies
{
    public class WorkplaceService : IService<WorkplaceDTO>
    {
        private readonly IRepository<Workplace> _workplaceRepository;

        public WorkplaceService(IRepository<Workplace> workplaceRepository)
        {
            _workplaceRepository = workplaceRepository;
        }

        public async Task CreateAsync(WorkplaceDTO item)
        {
            if (item == null)
            {
                //
                throw new ArgumentNullException("item");
            }
            Workplace workplace = WorkplaceMapper.FromDTO(item);
            await _workplaceRepository.CreateAsync(workplace);
        }

        public async Task DeleteAsync(WorkplaceDTO item)
        {
            Workplace workplace = WorkplaceMapper.FromDTO(item);
            await _workplaceRepository.DeleteAsync(workplace);
        }

        public void Dispose()
        {
            _workplaceRepository.Dispose();
        }

        public IList<WorkplaceDTO> GetAll()
        {
            List<Workplace> workplaces = _workplaceRepository.GetAll().ToList();
            List<WorkplaceDTO> list = WorkplaceMapper.ToDTO(workplaces);
            return list;
        }

        public async Task<WorkplaceDTO> GetByIdAsync(int id)
        {
            var workplace = await _workplaceRepository.GetByIdAsync(id);
            WorkplaceDTO workplaceDTO = WorkplaceMapper.ToDTO(workplace);
            return workplaceDTO;
        }

        public async Task UpdateAsync(WorkplaceDTO item)
        {
            Workplace workplace = WorkplaceMapper.FromDTO(item);
            await _workplaceRepository.UpdateAsync(workplace);
        }
    }
}
