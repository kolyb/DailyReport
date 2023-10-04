using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class DeleteWorkplaceModel : PageModel
    {
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public DeleteWorkplaceModel(IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
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
            WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(id);
            Description = workplaceDTO.Description;
            AdressCity = workplaceDTO.AdressCity;
            AdressStreet = workplaceDTO.AdressStreet;
            AdressHouse = workplaceDTO.AdressHouse;
        }

        public async Task<IActionResult> OnPost()
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


                    await _serviceWorkplaceDTO.DeleteAsync(workplaceDTO);
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
