using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class Remove_BemærkningerAndBeskrivelse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bemaerkninger",
                table: "Ferieboliger");

            migrationBuilder.DropColumn(
                name: "Beskrivelse",
                table: "Ferieboliger");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Bemaerkninger",
                table: "Ferieboliger",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Beskrivelse",
                table: "Ferieboliger",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
