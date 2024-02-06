using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Required]
        public string Head { set; get; }
        [Required]
        public string a { set; get; }
        [Required]
        public string b { set; get; }
        public string? c { set; get; }
        public string? d { set; get; }
        public byte SelectedAnswer { set; get; } = 0;
        public Exam Exam { set; get; }
        public int ExamId { set; get; }
        public bool Check { set; get; } = false;

    }
}
