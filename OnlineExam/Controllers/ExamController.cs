using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.Repository.DashboardRepo;
using OnlineExam.Repository.ExamRepos;
using OnlineExam.Repository.QuestionsRepo;
using OnlineExam.ViewModels;
using System.Security.Claims;

namespace OnlineExam.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IExamRepo _examContext;
        private readonly IQuestionRepo _questionContext;
        private readonly IDashboardRepo _dashboardContext;
        public ExamController(IExamRepo examContext, IQuestionRepo questionContext, IDashboardRepo dashboardContext)
        {
            this._examContext = examContext;
            this._questionContext = questionContext;
            this._dashboardContext = dashboardContext;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var Examlist = _examContext.GetAllExams(userId);

            return View(Examlist);
        }

        [HttpGet]
        public IActionResult CreateExam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExam(Exam item)
        {
            _examContext.CreateExam(item, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction("Index");
        }

        public IActionResult EditExam(int Id)
        {
            var item = _examContext.FindExam(Id);

            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExam(Exam item)
        {
            _examContext.EditExam(item.ExamId, item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var remove = _examContext.RemoveExam(Id);
            if(remove == false)
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewQuestions(int Id)
        {
            var exam = _examContext.FindExam(Id);
            if(exam is not null)
            {
                var examwithquestions = _questionContext.listexq(Id);
                return View(examwithquestions);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult CreateQuestion(int Id)
        {
            var question = new Question();

            var exam = _examContext.FindExam(Id);

            if(exam is null)
            {
                return NotFound();
            }

            question.ExamId = Id;
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuestion(Question item)
        {

            int id = item.ExamId;

            _questionContext.CreateQuestion(item);

            return RedirectToAction("ViewQuestions", new { Id = id });
        }

        [HttpGet]
        public IActionResult DeleteQuestion(int Id)
        {
            var question = _questionContext.FindQuestion(Id);

            int id = question.ExamId;

            _questionContext.DeleteQuestion(Id);

            return RedirectToAction("ViewQuestions", new { Id = id });
        }

        [HttpGet]
        public IActionResult EditQuestion(int Id)
        {
            var question = _questionContext.FindQuestion(Id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuestion(Question item)
        {
            _questionContext.EditQuestion(item);
            return RedirectToAction("ViewQuestions", new { Id = item.ExamId });
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var dashboards = _dashboardContext.Dashboards();

            return View(dashboards);
        }

        [HttpGet]
        public IActionResult ViewResults(int id)
        {
            var model = _dashboardContext.GetResult(id);
            if(model is null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        public IActionResult ExamResultDetails(int id)
        {
            var model = _dashboardContext.ExamDetails(id);
            if(model is null)
                return NotFound();

            return View(model);
        }
    }
}
