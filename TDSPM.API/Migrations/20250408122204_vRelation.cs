using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDSPM.API.Migrations
{
    /// <inheritdoc />
    public partial class vRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryCar",
                columns: table => new
                {
                    AccessoriesId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CarsId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryCar", x => new { x.AccessoriesId, x.CarsId });
                    table.ForeignKey(
                        name: "FK_AccessoryCar_Accessory_AccessoriesId",
                        column: x => x.AccessoriesId,
                        principalTable: "Accessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoryCar_CarKeller_CarsId",
                        column: x => x.CarsId,
                        principalTable: "CarKeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryCar_CarsId",
                table: "AccessoryCar",
                column: "CarsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryCar");

            migrationBuilder.DropTable(
                name: "Accessory");
        }
    }
}
