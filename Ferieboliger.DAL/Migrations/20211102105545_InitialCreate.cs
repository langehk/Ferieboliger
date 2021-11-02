using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brugere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brugere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faciliteter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faciliteter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ferieboliger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoeglerTilgaengelig = table.Column<int>(type: "int", nullable: false),
                    PrisLav = table.Column<int>(type: "int", nullable: false),
                    PrisHoej = table.Column<int>(type: "int", nullable: false),
                    AnkomstTidspunkt = table.Column<TimeSpan>(type: "time", nullable: true),
                    AfgangTidspunkt = table.Column<TimeSpan>(type: "time", nullable: true),
                    BeskatningLav = table.Column<int>(type: "int", nullable: false),
                    BeskatningHoej = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SendNoegler = table.Column<bool>(type: "bit", nullable: false),
                    AntalSovepladser = table.Column<int>(type: "int", nullable: false),
                    AntalBadevaerelser = table.Column<int>(type: "int", nullable: false),
                    AntalPersoner = table.Column<int>(type: "int", nullable: false),
                    AntalHusdyr = table.Column<int>(type: "int", nullable: false),
                    HusdyrTilladt = table.Column<bool>(type: "bit", nullable: false),
                    AntalKvadratmeter = table.Column<int>(type: "int", nullable: false),
                    Grundareal = table.Column<int>(type: "int", nullable: false),
                    AfstandStrand = table.Column<int>(type: "int", nullable: false),
                    AfstandRestaurant = table.Column<int>(type: "int", nullable: false),
                    AfstandIndkoeb = table.Column<int>(type: "int", nullable: false),
                    Bemaerkninger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferieboliger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vej = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FerieboligId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresser_Ferieboliger_FerieboligId",
                        column: x => x.FerieboligId,
                        principalTable: "Ferieboliger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookinger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    FerieboligId = table.Column<int>(type: "int", nullable: false),
                    UdlejDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AfrejseDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoeglerReturneret = table.Column<bool>(type: "bit", nullable: false),
                    NoeglerSendt = table.Column<bool>(type: "bit", nullable: false),
                    Pris = table.Column<int>(type: "int", nullable: false),
                    Kommentarer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointPris = table.Column<int>(type: "int", nullable: false),
                    Beskatning = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookinger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookinger_Brugere_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Brugere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookinger_Ferieboliger_FerieboligId",
                        column: x => x.FerieboligId,
                        principalTable: "Ferieboliger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilitetFeriebolig",
                columns: table => new
                {
                    FaciliteterId = table.Column<int>(type: "int", nullable: false),
                    FerieboligerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitetFeriebolig", x => new { x.FaciliteterId, x.FerieboligerId });
                    table.ForeignKey(
                        name: "FK_FacilitetFeriebolig_Faciliteter_FaciliteterId",
                        column: x => x.FaciliteterId,
                        principalTable: "Faciliteter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilitetFeriebolig_Ferieboliger_FerieboligerId",
                        column: x => x.FerieboligerId,
                        principalTable: "Ferieboliger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filoplysninger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FerieboligId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filoplysninger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filoplysninger_Ferieboliger_FerieboligId",
                        column: x => x.FerieboligId,
                        principalTable: "Ferieboliger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresser_FerieboligId",
                table: "Adresser",
                column: "FerieboligId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_BrugerId",
                table: "Bookinger",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_FerieboligId",
                table: "Bookinger",
                column: "FerieboligId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitetFeriebolig_FerieboligerId",
                table: "FacilitetFeriebolig",
                column: "FerieboligerId");

            migrationBuilder.CreateIndex(
                name: "IX_Filoplysninger_FerieboligId",
                table: "Filoplysninger",
                column: "FerieboligId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresser");

            migrationBuilder.DropTable(
                name: "Bookinger");

            migrationBuilder.DropTable(
                name: "FacilitetFeriebolig");

            migrationBuilder.DropTable(
                name: "Filoplysninger");

            migrationBuilder.DropTable(
                name: "Brugere");

            migrationBuilder.DropTable(
                name: "Faciliteter");

            migrationBuilder.DropTable(
                name: "Ferieboliger");
        }
    }
}
