using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangedRequestEntity2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeadId",
                table: "Requests",
                newName: "ProjectLead");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentLeadId",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentLeadId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "ProjectLead",
                table: "Requests",
                newName: "LeadId");
        }
    }
}
