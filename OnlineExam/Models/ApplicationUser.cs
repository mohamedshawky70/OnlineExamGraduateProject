using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace OnlineExam.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength (100)]
        public string FirstName { get; set; }
        [Required, MaxLength (100)]
        public string LastName { get; set; }

        public List<Exam> Exams { set; get; }

    }
}
