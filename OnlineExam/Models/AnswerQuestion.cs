using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Models
{
    public class AnswerQuestion
    {
        public int AnswerQuestionId { get; set; }
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
        public int Index { set; get; }
        [Required]
        public string Head { set; get; }
        [Required]
        public string a { set; get; }
        [Required]
        public string b { set; get; }
        public string? c { set; get; }
        public string? d { set; get; }
        public byte SelectedAnswer { set; get; } = 0;
        public byte TrueAnswer { set; get; } = 5;
        public bool Check { set; get; } = false;
    }
}
