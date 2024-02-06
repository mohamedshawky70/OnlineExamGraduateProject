using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ExamListAndNumQuestoins
    {
        // public List<Exam> exams { set; get; }

        // public List<int> numOfQuestions { set; get; }

        // public List<DateTime> EndTime { set; get; }

        public Exam Exam {get;set;}
        public List<Question> Questions { set; get; }
    }
}
