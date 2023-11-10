using DailyReport.BusinessLogic.ExceptionValidators;
using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Mappers;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.DataAccess.Interfaces;
using DailyReport.DataAccess.Models;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.BusinessLogic.Servicies
{
    public class WorkplaceService : IService<WorkplaceDTO>
    {
        private readonly IRepository<Workplace> _workplaceRepository;

        public WorkplaceService(IRepository<Workplace> workplaceRepository)
        {
            _workplaceRepository = workplaceRepository;
        }

        public async Task CreateAsync(WorkplaceDTO? item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not create a workplace");
            }

            if (WorkplaceValidator.WorkplaceExists(
                item.Description,
                item.AdressCity, 
                item.AdressStreet,
                item.AdressHouse,
                item.UserIdentityEmail,
                _workplaceRepository))
            {
                throw new ValidationException($"Workplcace '{item.Description} {item.AdressCity}, {item.AdressStreet}, " +
                    $"{item.AdressHouse}' already exists");
            }

            Workplace workplace = WorkplaceMapper.FromDTO(item);
            await _workplaceRepository.CreateAsync(workplace);
        }

        public async Task DeleteAsync(WorkplaceDTO? item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not delete a workplace");
            }

            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }

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

        public async Task<WorkplaceDTO> GetByIdAsync(int? id)
        {   
            if(id <= 0)
            {
                throw new ValidationException("Can not use");
            }

            if (WorkplaceValidator.WithoutWorkplaceCanNotDeleteAndEdit(
                id,
                _workplaceRepository))
            {
                throw new ValidationException("Can not delete and edit Without workplace");
            }

            var workplace = await _workplaceRepository.GetByIdAsync(id);
            WorkplaceDTO workplaceDTO = WorkplaceMapper.ToDTO(workplace);
            return workplaceDTO;
        }

        public async Task UpdateAsync(WorkplaceDTO? item)
        {
            if (item == null)
            {
                throw new ValidationException("Can not update a workplace");
            }

            if (item.Id <= 0)
            {
                throw new ValidationException("It is impossible");
            }

            Workplace workplace = WorkplaceMapper.FromDTO(item);
            await _workplaceRepository.UpdateAsync(workplace);
        }
    }
}
