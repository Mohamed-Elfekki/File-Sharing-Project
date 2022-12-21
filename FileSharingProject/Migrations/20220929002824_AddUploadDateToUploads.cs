using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileSharingProject.Migrations
{
    public partial class AddUploadDateToUploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "Uploads",
                newName: "Size");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Uploads",
                nullable: false,
                defaultValueSql:"getDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Uploads");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Uploads",
                newName: "size");
        }
    }
}
