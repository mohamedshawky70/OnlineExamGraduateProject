using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ListOfQAndExamId
    {
        public int Id { set; get; }
        public string ExamName { set; get; }
        public DateTime? StartTime { set; get; }
        public List<Question> questions { set; get; }
    }
}
