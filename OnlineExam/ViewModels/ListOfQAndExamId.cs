using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ListOfQAndExamId
    {
        public List<Question> questions { set; get; }

        public string ExamName { set; get; }   

        public DateTime ?StartTime { set; get; }

        public int Id { set;get; }
    }
}
