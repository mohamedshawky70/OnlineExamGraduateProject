using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.ExamRepos
{
    public class ExamRepo : IExamRepo
    {
        private readonly ApplicationDbContext _context;

        public ExamRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void CreateExam(Exam exam, string userId)
        {
            exam.ApplicationUserId = userId;
            DateTime a = (DateTime)exam.StartTime;
            a = a.AddMinutes(exam.Duration);
            exam.EndTime = a;

            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void EditExam(int id, Exam exam)
        {
            var oldExam = FindExam(id);
            oldExam.Title = exam.Title;
            oldExam.Duration = exam.Duration;
            _context.SaveChanges();
        }

        public Exam FindExam(int id)
        {
            var exam = _context.Exams.FirstOrDefault(X => X.ExamId == id);
            return exam;
        }

        public List<ExamListAndNumQuestoins> GetAllExams(string userId)
        {
            List<ExamListAndNumQuestoins> examlist = new List<ExamListAndNumQuestoins>();
            var exams = _context.Exams.Where(X => X.ApplicationUserId == userId).ToList();
            foreach (var exam in exams)
            {
                var questions = _context.Questions.Where(X => X.ExamId == exam.ExamId).ToList();
                examlist.Add(new ExamListAndNumQuestoins() { Exam = exam, Questions = questions });
            }
            return examlist;
        }

        public bool RemoveExam(int examId)
        {
            var exam = FindExam(examId);
            if (exam is not null)
            {
                var questions = _context.Questions.Where(X => X.ExamId == examId).ToList();
                foreach (var q in questions)
                {
                    _context.Questions.Remove(q);
                }
                _context.Exams.Remove(exam);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}