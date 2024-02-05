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
        ExamListAndNumQuestoins TeacherwithExams();
        void CreateExam (Exam exam);
        void EditExam (int id);
        Exam FindExam(int id);
        void EditExam (int id, Exam exam);
    }
}