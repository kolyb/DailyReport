using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class EditWorkplaceModel : PageModel
    {
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public EditWorkplaceModel(IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public string? AdressCity { get; set; }

        [BindProperty]
        public string? AdressStreet { get; set; }

        [BindProperty]
        public string? AdressHouse { get; set; }

        public async Task OnGet(int id)
        {
            try
            {
                WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(id);
                Id = workplaceDTO.Id;
                Description = workplaceDTO.Description;
                AdressCity = workplaceDTO.AdressCity;
                AdressStreet = workplaceDTO.AdressStreet;
                AdressHouse = workplaceDTO.AdressHouse;
            }
            catch (ValidationException ex) 
            { 
                Content (ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(Id);
                    if (workplaceDTO != null)
                    {
                        workplaceDTO.Id = Id;
                        workplaceDTO.Description = Description;
                        workplaceDTO.AdressCity = AdressCity;
                        workplaceDTO.AdressStreet = AdressStreet;
                        workplaceDTO.AdressHouse = AdressHouse;

                        await _serviceWorkplaceDTO.UpdateAsync(workplaceDTO);
                    }
                }
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
