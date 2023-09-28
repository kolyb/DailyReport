using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyReport.WebLayer.Pages.WorkLocation
{
    public class CreateWorkLocationModel : PageModel
    {
        private readonly IService<WorkLocationDTO> _serviceWorkLocationDTO;
        private readonly IService<PersonDTO> _servicePersonDTO;

        public CreateWorkLocationModel(IService<WorkLocationDTO> serviceWorkLocationDTO, 
            IService<PersonDTO> servicePersonDTO)
        {
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
            _servicePersonDTO = servicePersonDTO;
        }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public string? AdressWorkLocation { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        [BindProperty]
        public string? LastName { get; set; }

        public List<SelectListItem>? Options { get; set; }

        public IEnumerable<PersonDTO>? PersonDTOs { get; set; }

        public void OnGet()
        {
            Options = _servicePersonDTO.GetAll().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.LastName
                                  }).ToList();
        }

        public async Task<IActionResult> OnPost() 
        {
            PersonDTOs = _servicePersonDTO.GetAll().Where(i => i.Id == PersonId);

            foreach (var item in PersonDTOs)
            {
                LastName= item.LastName;
            }

            if (PersonId == 0)
            {
                return RedirectToPage("Index");
            }

            if (ModelState.IsValid)
            {
                WorkLocationDTO workLocationDTO = new WorkLocationDTO();
                workLocationDTO.PersonId = PersonId;
                workLocationDTO.Description = Description;
                workLocationDTO.AdressWorkLocation = AdressWorkLocation;

                await _serviceWorkLocationDTO.CreateAsync(workLocationDTO);

            }
            return RedirectToPage("Index");
        }

        public ActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
