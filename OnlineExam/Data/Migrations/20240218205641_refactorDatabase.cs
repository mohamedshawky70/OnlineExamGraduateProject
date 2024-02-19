using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Data.Migrations
{
    public partial class refactorDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSubmitted",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSubmitted",
                table: "Answers");
        }
    }
}
