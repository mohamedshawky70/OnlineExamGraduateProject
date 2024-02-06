using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Data;
using OnlineExam.Models;
using OnlineExam.ViewModels;

namespace OnlineExam.Repository.DashboardRepo
{
    public class DashboardRepo : IDashboardRepo
    {
        private readonly ApplicationDbContext _dashboardContext;
        public DashboardRepo(ApplicationDbContext dashboardContext)
        {
            this._dashboardContext = dashboardContext;
        }
        public List<DashboardViewModel> Dashboards()
        {
            List<DashboardViewModel> dashboards = new List<DashboardViewModel>();

            var answers = _dashboardContext.Answers.ToList();

            foreach (var answer in answers)
            {
                DashboardViewModel item = new DashboardViewModel
                {
                    StudentId = answer.StudentNationalId,
                    StudentName = answer.StudentName,
                    Score = (int)answer.Score,
                    ExamName = _dashboardContext.Exams.First(X => X.ExamId == answer.ExamId).Title
                };

                dashboards.Add(item);
            }

            return dashboards;
        }

        public ResultsModel GetResult(int examId)
        {
            var exam = _dashboardContext.Exams.FirstOrDefault(X => X.ExamId == examId);
            if (exam is null)
                return null;

            ResultsModel model = new ResultsModel();

            model.ExamName = exam.Title;

            model.answers = _dashboardContext.Answers.Where(i => i.ExamId == examId).ToList();

            int total = model.answers.Count;
            int numOFQuestions = _dashboardContext.Questions.Where(i => i.ExamId == examId).Count();
            int critical = numOFQuestions / 2;
            int numOfSucceeded = 0, sumOfScores = 0;
            model.isStudentPassed = new List<bool>();
            model.StudentsStatus = new List<String>();

            foreach (var i in model.answers)
            {
                if (i.Score >= critical)
                {
                    numOfSucceeded++;
                    model.isStudentPassed.Add(true);
                }
                else model.isStudentPassed.Add(false);
                model.StudentsStatus.Add(GetLetterGrade((int)i.Score, total));
                sumOfScores += (int)i.Score;

            }

            model.numberOfPassedStudent = numOfSucceeded;
            model.numberOfFailedStudent = total - numOfSucceeded;
            total = Math.Max(total, 1);
            model.averageGrade = sumOfScores / total;

            return model;
        }

        public string GetLetterGrade(int totalScore, int totalQuestions)
        {
            double scorePercent = ((double)totalScore / totalQuestions) * 100;
            string letterGrade;

            if (scorePercent >= 90)
                letterGrade = "A+";
            else if (scorePercent >= 85)
                letterGrade = "A";
            else if (scorePercent >= 80)
                letterGrade = "A-";
            else if (scorePercent >= 75)
                letterGrade = "B+";
            else if (scorePercent >= 70)
                letterGrade = "B";
            else if (scorePercent >= 65)
                letterGrade = "B-";
            else if (scorePercent >= 60)
                letterGrade = "C+";
            else if (scorePercent >= 55)
                letterGrade = "C";
            else if (scorePercent >= 50)
                letterGrade = "C-";
            else if (scorePercent >= 45)
                letterGrade = "D+";
            else if (scorePercent >= 40)
                letterGrade = "D";
            else
                letterGrade = "F";

            return letterGrade;
        }

        public ExamAnswerResult ExamDetails(int Id)
        {
            ExamAnswerResult model = new ExamAnswerResult();

            var ans = _dashboardContext.Answers.FirstOrDefault(A => A.AnswerId == Id);
            if(ans is null)
                return null;
                
            var exam = _dashboardContext.Exams.FirstOrDefault(X => X.ExamId == ans.ExamId);
            if(exam is null)
                return null;
                
            model.StudentName = ans.StudentName;
            model.ExamName = exam.Title;

            model.lstOfQuestionAnswers = _dashboardContext.AnswerQuestions.Where(i => i.AnswerId == Id).ToList();

            model.numOfQuestions = _dashboardContext.Questions.Where(i => i.ExamId == ans.ExamId).Count();

            int score = 0;

            foreach (var i in model.lstOfQuestionAnswers)
            {
                if (i.TrueAnswer == i.SelectedAnswer)
                    score++;
            }

            model.score = score;

            if (score * 2 >= model.numOfQuestions)
                model.passed = true;

            return model;
        }
    }
}