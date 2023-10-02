using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyReport.WebLayer.Pages.WorkLocation
{
    public class CreateWorkLocationModel : PageModel
    {
        private readonly IService<WorkLocationDTO> _serviceWorkLocationDTO;
        private readonly IService<PersonDTO> _servicePersonDTO;

        public CreateWorkLocationModel(IService<WorkLocationDTO> serviceWorkLocationDTO, 
            IService<PersonDTO> servicePersonDTO)
        {
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
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
                WorkLocationDTO workLocationDTO = new WorkLocationDTO();
                workLocationDTO.Description = Description;
                workLocationDTO.AdressCity = AdressCity;
                workLocationDTO.AdressStreet = AdressStreet;
                workLocationDTO.AdressHouse = AdressHouse;

                await _serviceWorkLocationDTO.CreateAsync(workLocationDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
