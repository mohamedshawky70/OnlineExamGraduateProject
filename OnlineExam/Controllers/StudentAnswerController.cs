
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.Repository.StudentAnswerRepo;
using OnlineExam.ViewModels;

namespace OnlineExam.Controllers
{
    public class StudentAnswerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentRepo _studentRepo;
        public StudentAnswerController(ApplicationDbContext context, IStudentRepo studentRepo)
        {
            _context = context;
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
                    return NotFound("You Submitted Your Exam :("); 
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
            var question = _context.AnswerQuestions.FirstOrDefault(item => item.Index == indexx.Index && item.AnswerId == indexx.AnswerId);
            if (question == null)
            {
                return RedirectToAction(nameof(Submit), new { AnswerId = indexx.AnswerId });
            }

            int NumOfQuestions = _context.AnswerQuestions.Where(i => i.AnswerId == indexx.AnswerId).Count();

            int ExamId = _context.Answers.Where(i => i.AnswerId == indexx.AnswerId).ToArray()[0].ExamId;
            var ExamName = _context.Exams.FirstOrDefault(i => i.ExamId == ExamId).Title;
            DateTime ExamDate = (DateTime)_context.Exams.FirstOrDefault(i => i.ExamId == ExamId).EndTime;

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
            int index;
            if (!int.TryParse(form["question.index"], out index))
            {
                index = 0;
            }

            int answerId = 0;

            if (int.TryParse(form["question.AnswerId"], out answerId))
            {

            }

            int answerIndex;


            if (int.TryParse(form["question.AnswerId"], out answerIndex))
            {
                var question = _context.AnswerQuestions.FirstOrDefault(q => q.Index == index && q.AnswerId == answerId);
                if (question != null)
                {
                    int selectedOption = 0;
                    if (int.TryParse(form["question.SelectedAnswer"], out selectedOption))
                    {
                        if (selectedOption == null)
                            selectedOption = 0;

                        if (selectedOption != 0)
                        {
                            question.SelectedAnswer = (byte)selectedOption;
                            var answer = _context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                            var studentAsnwerIndex = _context.StudentAnswerIndexs.FirstOrDefault(a => a.AnswerId == answerId && a.QuestionIndex == index);
                            if (studentAsnwerIndex is null)
                            {
                                studentAsnwerIndex = new StudentAnswerIndex()
                                {
                                    AnswerId = answerId,
                                    QuestionIndex = index,
                                    SelectedAnswer = question.SelectedAnswer,
                                    TrueAnswer = question.TrueAnswer
                                };
                                _context.StudentAnswerIndexs.Add(studentAsnwerIndex);
                            }
                            else studentAsnwerIndex.SelectedAnswer = question.SelectedAnswer;
                            _context.SaveChanges();
                            var answers = _context.StudentAnswerIndexs.Where(x => x.AnswerId == answerId && x.SelectedAnswer == x.TrueAnswer).ToList();
                            answer.Score = answers.Count();
                            _context.Answers.Update(answer);
                            _context.AnswerQuestions.Update(question);
                            _context.SaveChanges();
                        }

                    }
                }
            }

            string action = form["action"];
            if (action == "prev")
            {
                index--;
            }
            else if (action == "next")
            {
                index++;
            }
            else if (action == "submit")
            {
                return RedirectToAction("Submit", new { AnswerId = answerId });
            }
            return RedirectToAction(nameof(StudentExam), new IndexAndAnswerId { Index = index, AnswerId = answerId });
        }

        [HttpGet]
        public IActionResult Submit(int AnswerId)
        {
            Answer ans = _context.Answers.FirstOrDefault(i => i.AnswerId == AnswerId);
            if (ans is null)
                return NotFound();
            var answers = _context.StudentAnswerIndexs.Where(x => x.AnswerId == AnswerId && x.SelectedAnswer == x.TrueAnswer).ToList();
            ans.Score = answers.Count();
            ans.isSubmitted = true;
            _context.Answers.Update(ans);
            _context.SaveChanges();
            return View(ans.Score);
        }
    }
}
