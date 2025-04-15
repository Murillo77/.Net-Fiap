using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDSPM.API.Migrations
{
    /// <inheritdoc />
    public partial class vMarch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "March",
                table: "CarKeller",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "March",
                table: "CarKeller");
        }
    }
}
