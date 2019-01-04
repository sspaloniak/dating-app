using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineerApp.API.Migrations
{
    public partial class EditCardReaderColumnInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localization",
                table: "CardReaders");

            migrationBuilder.AddColumn<int>(
                name: "IdLocalization",
                table: "CardReaders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdLocalization",
                table: "CardReaders");

            migrationBuilder.AddColumn<string>(
                name: "Localization",
                table: "CardReaders",
                nullable: true);
        }
    }
}
