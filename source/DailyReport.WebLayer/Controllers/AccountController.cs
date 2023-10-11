using DailyReport.BusinessLogic.Interfaces.IdentityInterface;
using DailyReport.BusinessLogic.ModelsDTO.IdentityDTO;
using DailyReport.WebLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DailyReport.WebLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserIdentity _userIdentity;

        public AccountController(IUserIdentity userIdentity)
        {
            _userIdentity = userIdentity;
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
            //it will be from BLL
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
