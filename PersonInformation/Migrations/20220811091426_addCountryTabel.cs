using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonInformation.Migrations
{
    public partial class addCountryTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Info",
                newName: "CountryId");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Info_CountryId",
                table: "Info",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Info_Country_CountryId",
                table: "Info",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_Country_CountryId",
                table: "Info");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Info_CountryId",
                table: "Info");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Info",
                newName: "Country");
        }
    }
}
