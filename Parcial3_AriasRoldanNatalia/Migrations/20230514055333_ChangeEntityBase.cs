using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial3_AriasRoldanNatalia.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntityBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicules_Servicies_ServicesId",
                table: "Vehicules");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServicesId",
                table: "Vehicules",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicules_Servicies_ServicesId",
                table: "Vehicules",
                column: "ServicesId",
                principalTable: "Servicies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicules_Servicies_ServicesId",
                table: "Vehicules");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServicesId",
                table: "Vehicules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicules_Servicies_ServicesId",
                table: "Vehicules",
                column: "ServicesId",
                principalTable: "Servicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
