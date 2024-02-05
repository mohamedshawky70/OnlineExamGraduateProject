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

        public void CreateExam(Exam exam)
        {
            DateTime a = (DateTime)exam.StartTime;
            a = a.AddMinutes(exam.Duration);
            exam.EndTime = a;

            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void EditExam(int id)
        {
            throw new NotImplementedException();
        }

        public void EditExam(int id, Exam exam)
        {
            var oldExam = FindExam(id);
            exam.Title = oldExam.Title;
            exam.Duration = oldExam.Duration;
            _context.SaveChanges();
        }

        public Exam FindExam(int id)
        {
            var exam = _context.Exams.FirstOrDefault(X => X.ExamId == id);
            return exam;
        }

        public ExamListAndNumQuestoins TeacherwithExams()
        {
            throw new NotImplementedException();
        }
    }
}