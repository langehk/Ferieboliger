using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class TilfoejetPensionistFelterTilBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PensionistEmail",
                table: "Bookinger",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PensionistNavn",
                table: "Bookinger",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PensionistTelefon",
                table: "Bookinger",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PensionistEmail",
                table: "Bookinger");

            migrationBuilder.DropColumn(
                name: "PensionistNavn",
                table: "Bookinger");

            migrationBuilder.DropColumn(
                name: "PensionistTelefon",
                table: "Bookinger");
        }
    }
}
