using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonInformation.Migrations
{
    public partial class updatetabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Info",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
