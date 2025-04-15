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
            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "CarKeller",
                type: "NVARCHAR2(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "CarKeller",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(25)",
                oldMaxLength: 25);
        }
    }
}
