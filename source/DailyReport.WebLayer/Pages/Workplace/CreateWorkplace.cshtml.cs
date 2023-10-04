using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class CreateWorkplaceModel : PageModel
    {
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;
        private readonly IService<PersonDTO> _servicePersonDTO;

        public CreateWorkplaceModel(IService<WorkplaceDTO> serviceWorkplaceDTO, 
            IService<PersonDTO> servicePersonDTO)
        {
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
            _servicePersonDTO = servicePersonDTO;
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

            if (ModelState.IsValid)
            {
                WorkplaceDTO workplaceDTO = new WorkplaceDTO();
                workplaceDTO.Description = Description;
                workplaceDTO.AdressCity = AdressCity;
                workplaceDTO.AdressStreet = AdressStreet;
                workplaceDTO.AdressHouse = AdressHouse;

                await _serviceWorkplaceDTO.CreateAsync(workplaceDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
