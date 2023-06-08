using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.ViewModels;
using System.Configuration;
using System.Security.Claims;

namespace OnlineExam.Controllers
{
    public class ExamController : Controller
    {
        private  ApplicationDbContext _context;

        private string ConnectionString = "Server=(localdb)\\ProjectModels;Database=OnlineExam;Trusted_Connection=True;MultipleActiveResultSets=true";
        public IActionResult Index()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.
                UseSqlServer(ConnectionString);

            _context = new ApplicationDbContext(optionsBuilder.Options);


            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var exams = _context.Exams.Where(i=> i.ApplicationUserId == userId).ToList();



            return View(exams);
        }

        //Get
        public IActionResult CreateExam()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExam(Exam item)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            item.ApplicationUserId = userId;

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            _context.Exams.Add(item);
            _context.SaveChanges(); 

            return RedirectToAction("Index");
        }

        public IActionResult EditExam(int ?Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            var item = _context.Exams.Find(Id);

            if (item == null)
            {
                return NotFound();
            }


            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExam(Exam item)
        {
           // var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //item.ApplicationUserId = userId;

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            
            _context.Exams.Update(item);

            _context.SaveChanges();

            return RedirectToAction("Index");

            

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            var item = _context.Exams.Find(Id);

            if (item != null)
            {
                var examId = (int)Id;
                List<Question> questionsRelated = _context.Questions.Where(i => i.ExamId == examId).ToList();
                _context.Questions.RemoveRange(questionsRelated);

                _context.Exams.Remove(item);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int ?id)
        {
            // var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //item.ApplicationUserId = userId;

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            var item = _context.Exams.Find(id);
             
            if(item != null)
            {
                var examId = (int)id;
                List<Question> questionsRelated = _context.Questions.Where(i => i.ExamId == examId).ToList();
                _context.Questions.RemoveRange(questionsRelated);

                //foreach(var question in questionsRelated)
                //{
                //    _context.Questions.Remove(question);
                //}


                _context.Exams.Remove(item);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ViewQuestions(int ?Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            var lstOfQuestions = _context.Questions.Where(x => x.ExamId == Id).ToList();

            ListOfQAndExamId viewM = new ListOfQAndExamId();
            viewM.questions = lstOfQuestions;
            viewM.Id = (int)Id;


            return View(viewM);
        }

        public IActionResult CreateQuestion(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var q = new Question();

            q.ExamId = (int)Id;


            return View(q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuestion(Question item)
        {            

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            int? id = item.ExamId;


            _context.Questions.Add(item);
            _context.SaveChanges();

            return RedirectToAction("ViewQuestions", new {Id=id});
        }

        //[HttpPost]
        public IActionResult DeleteQuestion(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            var item = _context.Questions.Find(Id);

            int? id = item.ExamId;

            _context.Questions.Remove(item);          
            _context.SaveChanges();


            return RedirectToAction("ViewQuestions", new {Id = id});
        }



        public IActionResult EditQuestion(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }

            var item = _context.Questions.Find(Id);

            if (item == null)
            {
                return NotFound();
            }


            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuestion(Question item)
        {
            // var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //item.ApplicationUserId = userId;

            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.
                    UseSqlServer(ConnectionString);

                _context = new ApplicationDbContext(optionsBuilder.Options);

            }


            _context.Questions.Update(item);

            _context.SaveChanges();

            return RedirectToAction("ViewQuestions", new {Id = item.ExamId});



        }

    }
}
