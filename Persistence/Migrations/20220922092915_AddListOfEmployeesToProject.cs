using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddListOfEmployeesToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectLeadId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectLeadId",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectLeadId",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ProjectLeadId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectLeadId",
                table: "Projects",
                column: "ProjectLeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ProjectLeadId",
                table: "Projects",
                column: "ProjectLeadId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
