using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Data.Migrations
{
    public partial class AddAnswerQuestionModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "TrueAnswer",
                table: "AnswerQuestions",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<byte>(
                name: "SelectedAnswer",
                table: "AnswerQuestions",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "TrueAnswer",
                table: "AnswerQuestions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "SelectedAnswer",
                table: "AnswerQuestions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }
    }
}
