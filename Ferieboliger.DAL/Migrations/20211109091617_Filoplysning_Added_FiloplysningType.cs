using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class Filoplysning_Added_FiloplysningType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Filoplysninger",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Filoplysninger");
        }
    }
}
