using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.WorkLocation
{
    public class EditWorkLocationModel : PageModel
    {
        private readonly IService<WorkLocationDTO> _serviceWorkLocationDTO;

        public EditWorkLocationModel(IService<WorkLocationDTO> serviceWorkLocationDTO)
        {
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
        }

        [BindProperty(SupportsGet = true)]
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
            WorkLocationDTO workLocationDTO = await _serviceWorkLocationDTO.GetByIdAsync(id);
            Id = workLocationDTO.Id;
            Description = workLocationDTO.Description;
            AdressCity = workLocationDTO.AdressCity;
            AdressStreet = workLocationDTO.AdressStreet;
            AdressHouse = workLocationDTO.AdressHouse;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                WorkLocationDTO workLocationDTO = await _serviceWorkLocationDTO.GetByIdAsync(Id);
                if (workLocationDTO != null)
                {
                    workLocationDTO.Id = Id;
                    workLocationDTO.Description = Description;
                    workLocationDTO.AdressCity = AdressCity;
                    workLocationDTO.AdressStreet = AdressStreet;
                    workLocationDTO.AdressHouse = AdressHouse;


                    await _serviceWorkLocationDTO.UpdateAsync(workLocationDTO);
                }
            }

            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
