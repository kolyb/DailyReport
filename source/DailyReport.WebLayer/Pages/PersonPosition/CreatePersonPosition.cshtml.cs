using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.PersonPosition
{
    public class CreatePersonPositionModel : PageModel
    {
        private readonly IService<PersonPositionDTO> _servicePersonPositionDTO;

        public CreatePersonPositionModel(IService<PersonPositionDTO> servicePersonPositionDTO)
        {
            _servicePersonPositionDTO = servicePersonPositionDTO;
        }

        [BindProperty]
        public string? Position { get; set; }

        [BindProperty]
        public string? Expert { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                PersonPositionDTO personPositionDTO = new PersonPositionDTO();
                personPositionDTO.Position = Position;
                personPositionDTO.Expert = Expert;

                await _servicePersonPositionDTO.CreateAsync(personPositionDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
