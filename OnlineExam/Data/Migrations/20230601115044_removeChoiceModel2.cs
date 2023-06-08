using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Data.Migrations
{
    public partial class removeChoiceModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsD",
                table: "Questions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "a",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "b",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "c",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "d",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "a",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "b",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "c",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "d",
                table: "Questions");
        }
    }
}
