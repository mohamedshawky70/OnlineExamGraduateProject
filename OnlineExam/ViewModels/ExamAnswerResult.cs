using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ExamAnswerResult
    {
        public List<AnswerQuestion> lstOfQuestionAnswers {  get; set; }

        public string ExamName { set; get; }
        public string StudentName { set;get; }
        public int StudentId { set; get; }

        public int numOfQuestions { set; get; }
        public int score { set; get; }
        public bool passed { set; get; }=false;
        

    }
}
//start time exam
//name of student
//id of student
//score
//boolean passed or not
//grade
//number of questions