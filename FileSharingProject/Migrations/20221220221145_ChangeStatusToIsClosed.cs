using Microsoft.EntityFrameworkCore.Migrations;

namespace FileSharingProject.Migrations
{
    public partial class ChangeStatusToIsClosed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Contacts",
                newName: "IsClosed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsClosed",
                table: "Contacts",
                newName: "Status");
        }
    }
}
