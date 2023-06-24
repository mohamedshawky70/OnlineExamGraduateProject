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
            //string ConnectionString = "Server=(localdb)\\ProjectModels;Database=OnlineExam;Trusted_Connection=True;MultipleActiveResultSets=true";
            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.
            //    UseSqlServer(ConnectionString);

            //var _context = new ApplicationDbContext(optionsBuilder.Options);

            //var ExamIds = _context.Exams.Select(i => i.ExamId ).ToList();
            var model = new StringId { Id = "" };
            return View(model);
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