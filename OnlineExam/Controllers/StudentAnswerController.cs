
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.Repository.StudentAnswerRepo;
using OnlineExam.ViewModels;

namespace OnlineExam.Controllers
{
    public class StudentAnswerController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        public StudentAnswerController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var exam = _studentRepo.GetExam(id);

            if (exam is null)
                return RedirectToAction("Index", "Home");

            var StartTime = exam.StartTime;
            var EndTime = exam.EndTime;

            var model = new StudentInfo { ExamId = (int)id, NationalId = "", Name = "", StartTime = (DateTime)StartTime, EndTime = (DateTime)EndTime };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddAnswer(StudentInfo student)
        {
            int answerID = 0;

            var checkStudent = _studentRepo.GetAnswer(student.NationalId, student.ExamId);
            if (checkStudent is not null)
            {
                answerID = checkStudent.AnswerId;
                if (checkStudent.isSubmitted == true)
                {
                    return RedirectToAction("Submit", new { AnswerId = checkStudent.AnswerId });
                }
            }
            else
            {
                var StudentAns = _studentRepo.AddStudentAnswer(student);

                var questions = _studentRepo.GetQuestions(student.ExamId);

                _studentRepo.AddAnswerQuestions(questions, StudentAns.AnswerId);

                answerID = StudentAns.AnswerId;
            }

            IndexAndAnswerId IAndA = new IndexAndAnswerId { Index = 0, AnswerId = answerID };

            return RedirectToAction("StudentExam", IAndA);
        }

        [HttpGet]
        public IActionResult StudentExam(IndexAndAnswerId indexx)
        {
            var question = _studentRepo.GetAnswerQuestion(indexx.Index, indexx.AnswerId);

            if (question == null)
                return RedirectToAction(nameof(Submit), new { AnswerId = indexx.AnswerId });

            int NumOfQuestions = _studentRepo.GetAnswerQuestions(indexx.AnswerId).Count();

            var answer = _studentRepo.GetAnswer(indexx.AnswerId);

            int ExamId = answer.ExamId;
            var exam = _studentRepo.GetExam(ExamId);
            var ExamName = exam.Title;
            DateTime ExamDate = (DateTime)exam.EndTime;

            ExamInformation model = new ExamInformation
            {
                ExamName = ExamName,
                ExamDate = ExamDate,
                question = question,
                NumOfQuestions = NumOfQuestions
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult StudentExam(IFormCollection form)
        {
            int index = 0, answerId = 0;

            if (int.TryParse(form["question.index"], out index)) { }
            else return NotFound();

            if (int.TryParse(form["question.AnswerId"], out answerId)) { }
            else return NotFound();

            string action = form["action"];
            if (action == "prev")
                index--;
            else if (action == "next")
                index++;
            else if (action == "submit")
                return RedirectToAction("Submit", new { AnswerId = answerId });

            return RedirectToAction(nameof(StudentExam), new IndexAndAnswerId { Index = index, AnswerId = answerId });
        }

        [HttpPost]
        public JsonResult CalculateResult(int answerId, int selectedChoice, int questionIndex)
        {
            var question = _studentRepo.GetAnswerQuestion(questionIndex, answerId);
            if (question != null)
            {
                if (selectedChoice != 0)
                {
                    _studentRepo.UpdateAnswerQuestion(question, (byte)selectedChoice);
                    var studentAsnwerIndex = _studentRepo.GetStudentAnswerIndex(answerId, questionIndex);
                    _studentRepo.InsertOrUpdateStudentAnswerIndex(studentAsnwerIndex, answerId, questionIndex, question.SelectedAnswer, question.TrueAnswer);
                    _studentRepo.UpdateScore(answerId);
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Submit(int AnswerId)
        {
            var check = _studentRepo.CheckExistenceAnswer(AnswerId);
            if (check == false)
                return NotFound();

            int Score = _studentRepo.GetScoreAfterSubmission(AnswerId);
            return View(Score);
        }
    }
}
