using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class NyModelSpaerring_OmdoebIBookinger_FjernetStatusFeltFeriebolig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ferieboliger");

            migrationBuilder.RenameColumn(
                name: "UdlejDato",
                table: "Bookinger",
                newName: "StartDato");

            migrationBuilder.RenameColumn(
                name: "AfrejseDato",
                table: "Bookinger",
                newName: "SlutDato");

            migrationBuilder.CreateTable(
                name: "Spaerringer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FerieboligId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaerringer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaerringer_Ferieboliger_FerieboligId",
                        column: x => x.FerieboligId,
                        principalTable: "Ferieboliger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spaerringer_FerieboligId",
                table: "Spaerringer",
                column: "FerieboligId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spaerringer");

            migrationBuilder.RenameColumn(
                name: "StartDato",
                table: "Bookinger",
                newName: "UdlejDato");

            migrationBuilder.RenameColumn(
                name: "SlutDato",
                table: "Bookinger",
                newName: "AfrejseDato");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Ferieboliger",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
