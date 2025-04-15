using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDSPM.API.Migrations
{
    /// <inheritdoc />
    public partial class vInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarKeller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Plate = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Brand = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false),
                    Motorization = table.Column<string>(type: "NVARCHAR2(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarKeller", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarKeller");
        }
    }
}
