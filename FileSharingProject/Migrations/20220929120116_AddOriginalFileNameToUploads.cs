using Microsoft.EntityFrameworkCore.Migrations;

namespace FileSharingProject.Migrations
{
    public partial class AddOriginalFileNameToUploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "Uploads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "Uploads");
        }
    }
}
