using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int Duration { set; get; }
        public DateTime? AddedAt { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        //public List<Question> ?Questions { set; get; }

        public ApplicationUser ApplicationUser { set; get; }
        public string ApplicationUserId { get; set; }

        //public List<Answer> Answers { get; set; }
        //public int AnswerId { get; private set; }
    }
}
