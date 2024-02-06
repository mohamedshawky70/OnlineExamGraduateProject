using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.DashboardRepo
{
    public interface IDashboardRepo
    {
        List<DashboardViewModel> Dashboards();
        ResultsModel GetResult(int examId);
        ExamAnswerResult ExamDetails(int Id);
    }
}