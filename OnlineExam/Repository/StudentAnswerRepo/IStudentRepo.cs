using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Models;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.StudentAnswerRepo
{
    public interface IStudentRepo
    {
        Exam GetExam(int id);
        Answer GetAnswer(int AnswerId);
        Answer GetAnswer(string nationalId, int ExamId);
        Answer AddStudentAnswer(StudentInfo studentInfo);
        Answer GetStudentAnswer(string NationalId);
        List<Question> GetQuestions(int ExamId);
        void AddAnswerQuestions(List<Question> questions, int answerId);
        AnswerQuestion GetAnswerQuestion(int index, int AnswerId);
        List<AnswerQuestion> GetAnswerQuestions(int AnswerId);
        StudentAnswerIndex GetStudentAnswerIndex(int AnswerId, int Index);
        void InsertOrUpdateStudentAnswerIndex(StudentAnswerIndex studentAsnwerIndex, int AnswerId, int Index, byte selectedAnswer, byte trueAnswer);
        void UpdateScore(int AnswerId);
        void UpdateAnswerQuestion(AnswerQuestion question, byte selectedOption);
        bool CheckExistenceAnswer(int AnswerId);
        int GetScoreAfterSubmission(int AnswerId);
    }
}