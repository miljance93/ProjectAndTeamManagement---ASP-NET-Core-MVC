using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedRequestStatusEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestStatuses",
                columns: table => new
                {
                    RequestStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatuses", x => x.RequestStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "RequestStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "RequestStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Requests");
        }
    }
}
