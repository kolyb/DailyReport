using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Pages.Workplace
{
    public class EditWorkplaceModel : PageModel
    {
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public EditWorkplaceModel(IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        [BindProperty]
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
            try
            {
                WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(id);
                Id = workplaceDTO.Id;
                Description = workplaceDTO.Description;
                AdressCity = workplaceDTO.AdressCity;
                AdressStreet = workplaceDTO.AdressStreet;
                AdressHouse = workplaceDTO.AdressHouse;
            }
            catch (ValidationException ex) 
            { 
                Content (ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var regForDescriptionAndAdressHouse = "^[^!@#$%^&*()_+={}<>?:,.|'¹;?]+$";

                var regForAdressCityAndAdressStreet = "^[^0-9!@#$%^&*()_+={}<>?:,.|'¹;?]+$";

                if (ModelState.IsValid)
                {
                    WorkplaceDTO workplaceDTO = await _serviceWorkplaceDTO.GetByIdAsync(Id);
                    if (workplaceDTO != null)
                    {
                        workplaceDTO.Id = Id;
                        if (Description != null)
                        {
                            if (Regex.IsMatch(Description, regForDescriptionAndAdressHouse))
                            {
                                workplaceDTO.Description = Description;
                            }
                        }

                        if (AdressCity != null)
                        {
                            if (Regex.IsMatch(AdressCity, regForAdressCityAndAdressStreet))
                            {
                                workplaceDTO.AdressCity = AdressCity;
                            }
                        }

                        if (AdressStreet != null)
                        {
                            if (Regex.IsMatch(AdressStreet, regForAdressCityAndAdressStreet))
                            {
                                workplaceDTO.AdressStreet = AdressStreet;
                            }
                        }

                        if (AdressHouse != null)
                        {
                            if (Regex.IsMatch(AdressHouse, regForDescriptionAndAdressHouse))
                            {
                                workplaceDTO.AdressHouse = AdressHouse;
                            }
                        }

                        await _serviceWorkplaceDTO.UpdateAsync(workplaceDTO);
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
