using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.WebLayer.Pages.PersonPosition
{
    public class EditPersonPositionModel : PageModel
    {
        private readonly IService<PersonPositionDTO> _servicePersonPositionDTO;

        public EditPersonPositionModel(IService<PersonPositionDTO> servicePersonPositionDTO)
        {
            _servicePersonPositionDTO = servicePersonPositionDTO;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public string? Position { get; set; }

        [BindProperty]
        public string? Expert { get; set; }

        public async Task OnGet(int id)
        {
            PersonPositionDTO personPositionDTO = await _servicePersonPositionDTO.GetByIdAsync(id);
            Id = personPositionDTO.Id;
            Position = personPositionDTO.Position;
            Expert = personPositionDTO.Expert;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PersonPositionDTO personPositionDTO = await _servicePersonPositionDTO.GetByIdAsync(Id);
                if (personPositionDTO != null)
                {
                    personPositionDTO.Id = Id;
                    personPositionDTO.Position = Position;
                    personPositionDTO.Expert = Expert;

                    await _servicePersonPositionDTO.UpdateAsync(personPositionDTO);
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
