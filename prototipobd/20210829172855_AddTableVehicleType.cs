using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicles.Api.Migrations
{
    public partial class AddTableVehicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiclesType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesType_Description",
                table: "VehiclesType",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclesType");
        }
    }
}
