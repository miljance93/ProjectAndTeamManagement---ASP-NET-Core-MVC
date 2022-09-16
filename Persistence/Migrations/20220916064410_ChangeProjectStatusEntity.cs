using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangeProjectStatusEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProjectStatus");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ProjectStatus");

            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "ProjectStatus",
                newName: "ProjectStatusName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectStatusName",
                table: "ProjectStatus",
                newName: "Inactive");

            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "ProjectStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Completed",
                table: "ProjectStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
