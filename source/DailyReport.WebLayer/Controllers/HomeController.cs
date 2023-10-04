using DailyReport.BusinessLogic.Interfaces;
using DailyReport.BusinessLogic.ModelsDTO;
using DailyReport.WebLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DailyReport.WebLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<WorkplaceDTO> _serviceWorkplaceDTO;

        public HomeController(ILogger<HomeController> logger, IService<WorkplaceDTO> serviceWorkplaceDTO)
        {
            _logger = logger;
            _serviceWorkplaceDTO = serviceWorkplaceDTO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}