using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Position
{
    public class CreatePositionModel : PageModel
    {
        private readonly IService<PositionDTO> _servicePositionDTO;

        public CreatePositionModel(IService<PositionDTO> servicePositionDTO)
        {
            _servicePositionDTO = servicePositionDTO;
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
                PositionDTO positionDTO = new PositionDTO();
                positionDTO.Description = Description;

                await _servicePositionDTO.CreateAsync(positionDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
