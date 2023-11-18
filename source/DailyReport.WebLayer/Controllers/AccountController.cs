using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.Interfaces.IdentityInterface;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.BusinessLogic.ModelsDTO.IdentityDTO;
using DailyReport.WebLayer.Models;
using Microsoft.AspNetCore.Mvc;
using static DailyReport.BusinessLogic.Exceptions.ExceptionValidator;

namespace DailyReport.WebLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserIdentity _userIdentity;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public AccountController(IUserIdentity userIdentity,
            IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _userIdentity = userIdentity;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserIdentityDTO userDto = new UserIdentityDTO
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Password = model.Password,
                        RememberMe = model.RememberMe,
                    };

                    var result = await _userIdentity.Authenticate(userDto);                

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect login and (or) password");
                    }
                }
                return View(model);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserIdentityDTO userDto = new UserIdentityDTO
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Password = model.Password,
                    };

                    await _userIdentity.CreateAsync(userDto);

                    WorkplaceDTO workplaceDTO = new WorkplaceDTO();
                    workplaceDTO.UserIdentityEmail = model.Email;
                    workplaceDTO.Description = "Without workplace";
                    workplaceDTO.AdressCity = "Without workplace";
                    workplaceDTO.AdressStreet = "Without workplace";
                    workplaceDTO.AdressHouse = "Without workplace";

                    await _serviceWorkplaceDTO.CreateAsync(workplaceDTO);

                    return RedirectToAction("Index", "Home");

                }
                return View(model);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userIdentity.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
