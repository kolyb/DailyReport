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
        private readonly IService<WorkLocationDTO> _serviceWorkLocationDTO;

        public HomeController(ILogger<HomeController> logger, IService<WorkLocationDTO> serviceWorkLocationDTO)
        {
            _logger = logger;
            _serviceWorkLocationDTO = serviceWorkLocationDTO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchWorkLocation(string searchString)
        {
            IEnumerable<WorkLocationDTO> workLocationDTO = _serviceWorkLocationDTO.GetAll()
            .Where(l => l.Description == searchString);
            return (IActionResult)workLocationDTO;
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