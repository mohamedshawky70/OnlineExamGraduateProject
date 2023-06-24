using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineExam.ViewModels
{
    public class StringId
    {
        [Required(ErrorMessage = "Please enter an exam ID.")]
        [Display(Name = "Id")]
        public string Id { get; set; }
        public List<int>?ExamIds { get; set; }
    }
}
