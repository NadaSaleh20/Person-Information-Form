using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonInformation.Migrations
{
    public partial class addcityidcoulmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Info");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Info",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "citynum",
                table: "Info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Info_CityId",
                table: "Info",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Info_City_CityId",
                table: "Info",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_City_CityId",
                table: "Info");

            migrationBuilder.DropIndex(
                name: "IX_Info_CityId",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "citynum",
                table: "Info");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Info",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
