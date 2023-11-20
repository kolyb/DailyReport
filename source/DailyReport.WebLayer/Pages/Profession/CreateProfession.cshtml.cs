using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

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
            try
            {
                var reg = "^[^0-9!@#$%^&*()_+={}<>?:,.|'¹;?]+$";
                if (ModelState.IsValid)
                {
                    ProfessionDTO professionDTO = new ProfessionDTO();
                    if (Description != null)
                    {
                        if (Regex.IsMatch(Description, reg))
                        {
                            professionDTO.Description = Description;
                        }
                    }

                    await _serviceProfessionDTO.CreateAsync(professionDTO);
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
