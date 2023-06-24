using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ExamInformation
    {
        public int NumOfQuestions { set; get; }
        public string ExamName { set; get; }
        public DateTime ExamDate { set; get; }

        public AnswerQuestion question { set; get; }


    }
}
