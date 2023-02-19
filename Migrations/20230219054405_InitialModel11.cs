using Microsoft.EntityFrameworkCore.Migrations;

namespace Healthcare.webAPI.Migrations
{
    public partial class InitialModel11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Doctors");
        }
    }
}
