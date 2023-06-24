using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ResultsModel
    {
        public string ExamName { set; get; }
        public List<Answer> answers { set; get; }

        public int passed { set; get; }
        public int averageGrade { set; get; }

        public int Failed { set; get; }



    }
}
