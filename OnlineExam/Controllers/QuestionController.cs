using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OnlineExam.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}