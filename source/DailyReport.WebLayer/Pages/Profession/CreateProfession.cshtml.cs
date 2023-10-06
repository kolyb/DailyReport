using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Profession
{
    public class CreateProfessionModel : PageModel
    {
        private readonly IService<ProfessionDTO> _serviceProfessionDTO;

        public CreateProfessionModel(IService<ProfessionDTO> serviceProfessionDTO)
        {
            _serviceProfessionDTO = serviceProfessionDTO;
        }

        [BindProperty]
        public string? Description { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                ProfessionDTO professionDTO = new ProfessionDTO();
                professionDTO.Description = Description;

                await _serviceProfessionDTO.CreateAsync(professionDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
