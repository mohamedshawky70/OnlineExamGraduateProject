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
        Answer GetAnswer(string nationalId, int ExamId);
        Answer AddStudentAnswer(StudentInfo studentInfo);
        Answer GetStudentAnswer(string NationalId);
        List<Question> GetQuestions(int ExamId);
        void AddAnswerQuestions(List<Question> questions, int answerId);
    }
}