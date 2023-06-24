using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Data.Migrations
{
    public partial class AddAnswerQuestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerQuestions",
                columns: table => new
                {
                    AnswerQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    Head = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    a = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    b = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    c = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    d = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedAnswer = table.Column<byte>(type: "tinyint", nullable: false),
                    TrueAnswer = table.Column<byte>(type: "tinyint", nullable: false),
                    Check = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestions", x => x.AnswerQuestionId);
                    table.ForeignKey(
                        name: "FK_AnswerQuestions_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestions_AnswerId",
                table: "AnswerQuestions",
                column: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerQuestions");
        }
    }
}
