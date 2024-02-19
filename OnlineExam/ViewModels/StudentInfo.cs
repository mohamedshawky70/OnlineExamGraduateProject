namespace OnlineExam.ViewModels
{
    public class StudentInfo
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public int ExamId { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public bool Submit { get; set; }
    }
}
