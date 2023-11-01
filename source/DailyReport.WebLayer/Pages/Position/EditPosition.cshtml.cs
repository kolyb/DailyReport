using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.Position
{
    public class EditPositionModel : PageModel
    {
        private readonly IService<PositionDTO> _servicePositionDTO;

        public EditPositionModel(IService<PositionDTO> servicePositionDTO)
        {
            _servicePositionDTO = servicePositionDTO;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        public async Task OnGet(int id)
        {
            PositionDTO positionDTO = await _servicePositionDTO.GetByIdAsync(id);
            Id = positionDTO.Id;
            Description = positionDTO.Description;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PositionDTO positionDTO = await _servicePositionDTO.GetByIdAsync(Id);
                if (positionDTO != null)
                {
                    positionDTO.Id = Id;
                    positionDTO.Description = Description;

                    await _servicePositionDTO.UpdateAsync(positionDTO);
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
