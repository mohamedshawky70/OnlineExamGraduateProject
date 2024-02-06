using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Models;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.ExamRepos
{
    public interface IExamRepo
    {
        List<ExamListAndNumQuestoins> GetAllExams(string userId);
        void CreateExam (Exam exam, string userId);
        Exam FindExam(int id);
        void EditExam (int id, Exam exam);
        bool RemoveExam(int examId);
    }
}