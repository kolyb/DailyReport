using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

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
            try
            {
                var reg = "^[^0-9!@#$%^&*()_+={}<>?:,.|'¹;?]+$";

                if (ModelState.IsValid)
                {
                    PositionDTO positionDTO = new PositionDTO();
                    if (Description != null)
                    {
                        if (Regex.IsMatch(Description, reg))
                        {
                            positionDTO.Description = Description;
                        }
                    }
                    
                    await _servicePositionDTO.CreateAsync(positionDTO);
                }
            }
            catch (ValidationException ex) 
            {
                return Content (ex.Message);
            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
