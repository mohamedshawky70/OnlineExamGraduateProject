using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Models;

namespace OnlineExam.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClames", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

            builder.Entity<Exam>().Property(item => item.AddedAt)
                .HasDefaultValueSql("getdate()");

        }


        public DbSet<ApplicationUser> Users { set; get; }
        public DbSet<Exam> Exams { set; get; }
        public DbSet<Question> Questions { set; get; }
        public DbSet<AnswerQuestion> AnswerQuestions { set; get; }
        public DbSet<Answer> Answers { set; get; }
    }
}