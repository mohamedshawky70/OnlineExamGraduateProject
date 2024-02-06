using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.ViewModels;
using System.Diagnostics;

namespace OnlineExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated) // check if user is authenticated
            {
                return RedirectToAction("Dashboard", "Exam"); // redirect to ExamController if logged in
            }
            // var model = new StringId { Id = "" };
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