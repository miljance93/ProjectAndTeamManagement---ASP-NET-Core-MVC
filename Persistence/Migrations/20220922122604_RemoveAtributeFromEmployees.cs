using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RemoveAtributeFromEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectLeadId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectLeadId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectLeadId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectLeadId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectLeadId",
                table: "AspNetUsers",
                column: "ProjectLeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectLeadId",
                table: "AspNetUsers",
                column: "ProjectLeadId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
