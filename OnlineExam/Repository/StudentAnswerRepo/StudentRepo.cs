using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.StudentAnswerRepo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext _context;
        public StudentRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void AddAnswerQuestions(List<Question> questions, int answerId)
        {
            int idx = 0;
            foreach (var q in questions)
            {
                var ansQ = new AnswerQuestion
                {
                    Head = q.Head,
                    a = q.a,
                    b = q.b,
                    c = q.c,
                    d = q.d,
                    AnswerId = answerId,
                    TrueAnswer = q.SelectedAnswer,
                    Index = idx
                };

                idx++;
                _context.AnswerQuestions.Add(ansQ);
            }

            _context.SaveChanges();
        }

        public Answer AddStudentAnswer(StudentInfo studentInfo)
        {
            var answer = new Answer()
            {
                ExamId = studentInfo.ExamId,
                StudentNationalId = studentInfo.NationalId,
                StudentName = studentInfo.Name,
                Score = 0,
                isSubmitted = false
            };

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return answer;
        }

        public Answer GetAnswer(string nationalId, int ExamId)
        {
            var answer = _context.Answers.FirstOrDefault(a => a.StudentNationalId == nationalId && a.ExamId == ExamId);
            return answer;
        }

        public Exam GetExam(int id)
        {
            var exam = _context.Exams.FirstOrDefault(a => a.ExamId == id);
            return exam;
        }

        public List<Question> GetQuestions(int ExamId)
        {
            var questions = _context.Questions.Where(q => q.ExamId == ExamId).ToList();
            return questions;
        }

        public Answer GetStudentAnswer(string NationalId)
        {
            var studentAsnwer = _context.Answers.FirstOrDefault(A => A.StudentNationalId == NationalId);
            return studentAsnwer;
        }
    }
}