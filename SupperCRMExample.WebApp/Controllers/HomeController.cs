using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupperCRMExample.Models;
using SupperCRMExample.Services;
using SupperCRMExample.WebApp.Filters;
using SupperCRMExample.WebApp.Models;
using System.Diagnostics;

namespace SupperCRMExample.WebApp.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard([FromServices] IDashboardService dashboardService)
        {
            DashboardModel model = dashboardService.GetDashboardModel();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Home/GenFakeData
        public string GenFakeData([FromServices] IMockService mockService)
        {
            mockService.RunFakeGenerator();

            return "ok";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
