using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YellowCarrotApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                column: "TagName",
                value: "Pasta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagName",
                keyValue: "Pasta");
        }
    }
}
