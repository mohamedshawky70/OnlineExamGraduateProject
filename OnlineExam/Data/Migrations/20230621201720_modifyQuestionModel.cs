using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Data.Migrations
{
    public partial class modifyQuestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsA",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsB",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsC",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsD",
                table: "Questions");

            migrationBuilder.AddColumn<byte>(
                name: "SelectedAnswer",
                table: "Questions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedAnswer",
                table: "Questions");

            migrationBuilder.AddColumn<bool>(
                name: "IsA",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsB",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsC",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsD",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
