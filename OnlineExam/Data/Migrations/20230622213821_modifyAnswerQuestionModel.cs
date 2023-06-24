using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Data.Migrations
{
    public partial class modifyAnswerQuestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "AnswerQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "AnswerQuestions");
        }
    }
}
