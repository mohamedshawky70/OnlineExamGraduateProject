using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class StudentAnswerIndex
    {
        public int ID { get; set; }
        public int AnswerId { get; set; }
        public int QuestionIndex { get; set; }
        public byte SelectedAnswer { get; set; }
        public byte TrueAnswer { get; set; }
    }
}