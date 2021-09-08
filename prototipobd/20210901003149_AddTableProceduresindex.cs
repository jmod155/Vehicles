using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicles.Api.Migrations
{
    public partial class AddTableProceduresindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Procedures",
                newName: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_Description",
                table: "Procedures",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Procedures_Description",
                table: "Procedures");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Procedures",
                newName: "Descripcion");
        }
    }
}
