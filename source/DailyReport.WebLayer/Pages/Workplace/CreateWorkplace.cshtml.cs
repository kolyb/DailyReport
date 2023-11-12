using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class CreateWorkplaceModel : PageModel
    {
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public CreateWorkplaceModel(IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public string? AdressCity { get; set; }

        [BindProperty]
        public string? AdressStreet { get; set; }

        [BindProperty]
        public string? AdressHouse { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost() 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WorkplaceDTO workplaceDTO = new WorkplaceDTO();
                    workplaceDTO.UserIdentityEmail = User.Identity?.Name;
                    workplaceDTO.Description = Description;
                    workplaceDTO.AdressCity = AdressCity;
                    workplaceDTO.AdressStreet = AdressStreet;
                    workplaceDTO.AdressHouse = AdressHouse;

                    await _serviceWorkplaceDTO.CreateAsync(workplaceDTO);
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
