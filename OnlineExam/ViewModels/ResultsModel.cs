using OnlineExam.Models;

namespace OnlineExam.ViewModels
{
    public class ResultsModel
    {
        public string ExamName { set; get; }
        public List<Answer> answers { set; get; }
        public int numberOfPassedStudent { set; get; }
        public int numberOfFailedStudent { set; get; }   
        public List<bool> isStudentPassed { set; get; }
        public int averageGrade { set; get; }

        public List<String> StudentsStatus { set; get; }

    }
}
