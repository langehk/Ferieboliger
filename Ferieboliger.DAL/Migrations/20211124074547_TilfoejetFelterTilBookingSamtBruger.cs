using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class TilfoejetFelterTilBookingSamtBruger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Loennr",
                table: "Brugere",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Godkendt",
                table: "Bookinger",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prioritet",
                table: "Bookinger",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Loennr",
                table: "Brugere");

            migrationBuilder.DropColumn(
                name: "Godkendt",
                table: "Bookinger");

            migrationBuilder.DropColumn(
                name: "Prioritet",
                table: "Bookinger");
        }
    }
}
