using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDSPM.API.Migrations
{
    /// <inheritdoc />
    public partial class vCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Plate = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    BrandId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Motorization = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    March = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars1_Brand1_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars1_BrandId",
                table: "Cars1",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars1");

            migrationBuilder.DropTable(
                name: "Brand1");
        }
    }
}
