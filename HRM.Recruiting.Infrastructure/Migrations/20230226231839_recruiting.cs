using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Recruiting.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class recruiting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(50)",
                table: "SubmissionStatus",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "varchar(150)",
                table: "JobRequirement",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "varchar(100)",
                table: "JobRequirement",
                newName: "HiringManagerName");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SubmissionStatus",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobRequirement",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HiringManagerName",
                table: "JobRequirement",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SubmissionStatus",
                newName: "varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "JobRequirement",
                newName: "varchar(150)");

            migrationBuilder.RenameColumn(
                name: "HiringManagerName",
                table: "JobRequirement",
                newName: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(50)",
                table: "SubmissionStatus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(150)",
                table: "JobRequirement",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(100)",
                table: "JobRequirement",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }
    }
}
