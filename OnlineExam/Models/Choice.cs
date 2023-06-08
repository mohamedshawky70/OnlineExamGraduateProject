namespace OnlineExam.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string Content { set; get; }
        public bool IsTrue { get; set; } = false;

        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
