using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class Changed_Adress_PostalCode_ToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Postnummer",
                table: "Adresse",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Postnummer",
                table: "Adresse",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
