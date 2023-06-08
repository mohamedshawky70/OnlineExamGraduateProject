namespace OnlineExam.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string StudentNationalId { set; get; }
        public string StudentName { set; get; }

        public int ?Score { set; get; } 


        public Exam Exams { get; set; }
        public int ExamId { get; set; }

    }
}
