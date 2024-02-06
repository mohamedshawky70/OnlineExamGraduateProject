using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ExamAnswerResult
    {
        public int StudentId { set; get; }
        public string ExamName { set; get; }
        public string StudentName { set;get; }
        public int numOfQuestions { set; get; }
        public int score { set; get; }
        public bool passed { set; get; }=false;
        public List<AnswerQuestion> lstOfQuestionAnswers {  get; set; }
    }
}