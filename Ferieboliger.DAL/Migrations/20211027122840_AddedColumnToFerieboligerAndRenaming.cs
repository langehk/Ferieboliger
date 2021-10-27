using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class AddedColumnToFerieboligerAndRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Udlejet",
                table: "Ferieboliger");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookinger");

            migrationBuilder.RenameColumn(
                name: "AntalSoveplader",
                table: "Ferieboliger",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "NoeglerTilgaengelig",
                table: "Ferieboliger",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "AnkomstTidspunkt",
                table: "Ferieboliger",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "AfgangTidspunkt",
                table: "Ferieboliger",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "AntalSovepladser",
                table: "Ferieboliger",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntalSovepladser",
                table: "Ferieboliger");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Ferieboliger",
                newName: "AntalSoveplader");

            migrationBuilder.AlterColumn<bool>(
                name: "NoeglerTilgaengelig",
                table: "Ferieboliger",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnkomstTidspunkt",
                table: "Ferieboliger",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AfgangTidspunkt",
                table: "Ferieboliger",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Udlejet",
                table: "Ferieboliger",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookinger",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
