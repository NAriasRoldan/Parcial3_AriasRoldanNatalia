using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial3_AriasRoldanNatalia.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUniqueForVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicules_NumberPlate",
                table: "Vehicules");

            migrationBuilder.AlterColumn<string>(
                name: "NumberPlate",
                table: "Vehicules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumberPlate",
                table: "Vehicules",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_NumberPlate",
                table: "Vehicules",
                column: "NumberPlate",
                unique: true);
        }
    }
}
