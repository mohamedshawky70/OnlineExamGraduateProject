using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Data;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.QuestionsRepo
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly ApplicationDbContext _context;
        public QuestionRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public ListOfQAndExamId listexq(int examId)
        {
            var examwithquestions = new ListOfQAndExamId();
            var questions = _context.Questions.Where(X => X.ExamId == examId).ToList();
            var exam = _context.Exams.FirstOrDefault(X => X.ExamId == examId);
            examwithquestions.ExamName = exam.Title;
            examwithquestions.StartTime = exam.StartTime;
            examwithquestions.questions = questions;
            examwithquestions.Id = examId;

            return examwithquestions;
        }
    }
}