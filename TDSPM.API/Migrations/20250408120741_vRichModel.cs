using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDSPM.API.Migrations
{
    /// <inheritdoc />
    public partial class vRichModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "CarKeller");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "CarKeller",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CarKeller_BrandId",
                table: "CarKeller",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarKeller_Brand_BrandId",
                table: "CarKeller",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarKeller_Brand_BrandId",
                table: "CarKeller");

            migrationBuilder.DropIndex(
                name: "IX_CarKeller_BrandId",
                table: "CarKeller");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "CarKeller");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "CarKeller",
                type: "NUMBER(10)",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);
        }
    }
}
