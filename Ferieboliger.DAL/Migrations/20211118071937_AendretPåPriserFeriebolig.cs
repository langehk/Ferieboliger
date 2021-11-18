using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class AendretPåPriserFeriebolig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrisLav",
                table: "Ferieboliger",
                newName: "PrisLavWeekend");

            migrationBuilder.RenameColumn(
                name: "PrisHoej",
                table: "Ferieboliger",
                newName: "PrisLavUge");

            migrationBuilder.RenameColumn(
                name: "BeskatningLav",
                table: "Ferieboliger",
                newName: "PrisHoejWeekend");

            migrationBuilder.RenameColumn(
                name: "BeskatningHoej",
                table: "Ferieboliger",
                newName: "PrisHoejUge");

            migrationBuilder.AddColumn<int>(
                name: "BeskatningHoejUge",
                table: "Ferieboliger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeskatningHoejWeekend",
                table: "Ferieboliger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeskatningLavUge",
                table: "Ferieboliger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeskatningLavWeekend",
                table: "Ferieboliger",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeskatningHoejUge",
                table: "Ferieboliger");

            migrationBuilder.DropColumn(
                name: "BeskatningHoejWeekend",
                table: "Ferieboliger");

            migrationBuilder.DropColumn(
                name: "BeskatningLavUge",
                table: "Ferieboliger");

            migrationBuilder.DropColumn(
                name: "BeskatningLavWeekend",
                table: "Ferieboliger");

            migrationBuilder.RenameColumn(
                name: "PrisLavWeekend",
                table: "Ferieboliger",
                newName: "PrisLav");

            migrationBuilder.RenameColumn(
                name: "PrisLavUge",
                table: "Ferieboliger",
                newName: "PrisHoej");

            migrationBuilder.RenameColumn(
                name: "PrisHoejWeekend",
                table: "Ferieboliger",
                newName: "BeskatningLav");

            migrationBuilder.RenameColumn(
                name: "PrisHoejUge",
                table: "Ferieboliger",
                newName: "BeskatningHoej");
        }
    }
}
