using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.QuestionsRepo
{
    public interface IQuestionRepo
    {
        ListOfQAndExamId listexq(int examId);
    }
}