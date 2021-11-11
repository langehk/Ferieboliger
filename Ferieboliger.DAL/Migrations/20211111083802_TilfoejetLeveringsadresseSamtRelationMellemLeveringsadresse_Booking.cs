using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class TilfoejetLeveringsadresseSamtRelationMellemLeveringsadresse_Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Brugere");

            migrationBuilder.CreateTable(
                name: "Leveringsadresser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vej = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firmaadresse = table.Column<bool>(type: "bit", nullable: false),
                    Afdeling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leveringsadresser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leveringsadresser_Bookinger_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookinger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leveringsadresser_BookingId",
                table: "Leveringsadresser",
                column: "BookingId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leveringsadresser");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Brugere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
