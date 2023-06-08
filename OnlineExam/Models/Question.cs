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

        public bool IsA { set; get; }
        public bool IsB { set; get; }

        public bool IsC { set; get; }

        public bool IsD { set; get; }




        public Exam Exam { set; get; }
        public int ExamId { set; get; }

        public bool Check { set; get; } = false;

    }
}
