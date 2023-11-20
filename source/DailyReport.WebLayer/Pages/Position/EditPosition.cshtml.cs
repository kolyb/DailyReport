using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Position
{
    public class EditPositionModel : PageModel
    {
        private readonly IService<PositionDTO> _servicePositionDTO;

        public EditPositionModel(IService<PositionDTO> servicePositionDTO)
        {
            _servicePositionDTO = servicePositionDTO;
        }

        [BindProperty]
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
            try
            {
                var reg = "^[^0-9!@#$%^&*()_+={}<>?:,.|'¹;?]+$";
                if (ModelState.IsValid)
                {
                    PositionDTO positionDTO = await _servicePositionDTO.GetByIdAsync(Id);
                    if (positionDTO != null)
                    {
                        positionDTO.Id = Id;
                        if (Description != null)
                        {
                            if (Regex.IsMatch(Description, reg))
                            {
                                positionDTO.Description = Description;
                            }
                        }

                        await _servicePositionDTO.UpdateAsync(positionDTO);
                    }
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
