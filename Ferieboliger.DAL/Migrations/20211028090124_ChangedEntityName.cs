using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferieboliger.DAL.Migrations
{
    public partial class ChangedEntityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferieboliger_Adresse_Id",
                table: "Ferieboliger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse");

            migrationBuilder.RenameTable(
                name: "Adresse",
                newName: "Adresser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresser",
                table: "Adresser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferieboliger_Adresser_Id",
                table: "Ferieboliger",
                column: "Id",
                principalTable: "Adresser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferieboliger_Adresser_Id",
                table: "Ferieboliger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresser",
                table: "Adresser");

            migrationBuilder.RenameTable(
                name: "Adresser",
                newName: "Adresse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferieboliger_Adresse_Id",
                table: "Ferieboliger",
                column: "Id",
                principalTable: "Adresse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
