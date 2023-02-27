using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Recruiting.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class recruiting2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(500)",
                table: "JobRequirement",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobRequirement",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "HiringManagerName",
                table: "JobRequirement",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobRequirement",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "JobRequirement",
                newName: "varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobRequirement",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "HiringManagerName",
                table: "JobRequirement",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(500)",
                table: "JobRequirement",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");
        }
    }
}
