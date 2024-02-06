using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Data;
using OnlineExam.Models;
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

        public void CreateQuestion(Question question)
        {
            _context.Add(question);
            _context.SaveChanges();
        }

        public void DeleteQuestion(int Id)
        {
            var question = _context.Questions.FirstOrDefault(Q => Q.QuestionId == Id);
            if(question is not null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }

        public void EditQuestion(Question question)
        {
            _context.Questions.Update(question);

            _context.SaveChanges();
        }

        public Question FindQuestion(int Id)
        {
            var question = _context.Questions.FirstOrDefault(Q => Q.QuestionId == Id);
            return question;
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