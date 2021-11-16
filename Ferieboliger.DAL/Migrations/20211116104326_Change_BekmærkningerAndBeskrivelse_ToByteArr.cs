using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class Change_BekmærkningerAndBeskrivelse_ToByteArr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bemaerkninger",
                table: "Ferieboliger");

            migrationBuilder.DropColumn(
                name: "Beskrivelse",
                table: "Ferieboliger");
        }
    }
}
