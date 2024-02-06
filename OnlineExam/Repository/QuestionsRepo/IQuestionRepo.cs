using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Models;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.QuestionsRepo
{
    public interface IQuestionRepo
    {
        ListOfQAndExamId listexq(int examId);
        void CreateQuestion(Question question);
        void DeleteQuestion(int Id);
        Question FindQuestion(int Id);
        void EditQuestion(Question question);
    }
}