using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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

        public bool CheckExistenceAnswer(int AnswerId)
        {
            var answer = _context.Answers.FirstOrDefault(x => x.AnswerId == AnswerId);
            if (answer is null)
                return false;

            return true;
        }

        public Answer GetAnswer(string nationalId, int ExamId)
        {
            var answer = _context.Answers.FirstOrDefault(a => a.StudentNationalId == nationalId && a.ExamId == ExamId);
            return answer;
        }

        public Answer GetAnswer(int AnswerId)
        {
            var answer = _context.Answers.FirstOrDefault(a => a.AnswerId == AnswerId);
            return answer;
        }

        public AnswerQuestion GetAnswerQuestion(int index, int AnswerId)
        {
            var answerQuestion = _context.AnswerQuestions.FirstOrDefault(a => a.Index == index && a.AnswerId == AnswerId);
            return answerQuestion;
        }

        public List<AnswerQuestion> GetAnswerQuestions(int AnswerId)
        {
            var answerQuestions = _context.AnswerQuestions.Where(a => a.AnswerId == AnswerId).ToList();
            return answerQuestions;
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

        public int GetScoreAfterSubmission(int AnswerId)
        {
            var ans = GetAnswer(AnswerId);
            var answers = _context.StudentAnswerIndexs.Where(x => x.AnswerId == AnswerId && x.SelectedAnswer == x.TrueAnswer).ToList();
            ans.Score = answers.Count();
            ans.isSubmitted = true;
            _context.SaveChanges();
            return (int)ans.Score;
        }

        public Answer GetStudentAnswer(string NationalId)
        {
            var studentAsnwer = _context.Answers.FirstOrDefault(A => A.StudentNationalId == NationalId);
            return studentAsnwer;
        }

        public StudentAnswerIndex GetStudentAnswerIndex(int AnswerId, int Index)
        {
            var studentAsnwerIndex = _context.StudentAnswerIndexs.FirstOrDefault(a => a.AnswerId == AnswerId && a.QuestionIndex == Index);
            return studentAsnwerIndex;
        }

        public void InsertOrUpdateStudentAnswerIndex(StudentAnswerIndex studentAsnwerIndex, int AnswerId, int Index, byte selectedAnswer, byte trueAnswer)
        {
            if (studentAsnwerIndex is null)
            {
                studentAsnwerIndex = new StudentAnswerIndex()
                {
                    AnswerId = AnswerId,
                    QuestionIndex = Index,
                    SelectedAnswer = selectedAnswer,
                    TrueAnswer = trueAnswer
                };
                _context.StudentAnswerIndexs.Add(studentAsnwerIndex);
            }
            else studentAsnwerIndex.SelectedAnswer = selectedAnswer;
            _context.SaveChanges();
        }

        public void UpdateAnswerQuestion(AnswerQuestion question, byte selectedOption)
        {
            question.SelectedAnswer = selectedOption;
            _context.SaveChanges();
        }

        public void UpdateScore(int AnswerId)
        {
            var answer = GetAnswer(AnswerId);
            var answers = _context.StudentAnswerIndexs.Where(x => x.AnswerId == AnswerId && x.SelectedAnswer == x.TrueAnswer).ToList();
            answer.Score = answers.Count();
            _context.SaveChanges();
        }
    }
}