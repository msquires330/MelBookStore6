using Microsoft.EntityFrameworkCore.Migrations;

namespace MelBookStore.Migrations
{
    public partial class AuthorNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Projects",
                newName: "AuthorLast");

            migrationBuilder.AddColumn<string>(
                name: "AuthorFirst",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorMiddle",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorFirst",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AuthorMiddle",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "AuthorLast",
                table: "Projects",
                newName: "Author");
        }
    }
}
