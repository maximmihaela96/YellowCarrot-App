using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YellowCarrotApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIngrediensName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredienceNamn",
                table: "Ingredience",
                newName: "IngrediensNamn");

            migrationBuilder.RenameColumn(
                name: "IngredienceId",
                table: "Ingredience",
                newName: "IngrediensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngrediensNamn",
                table: "Ingredience",
                newName: "IngredienceNamn");

            migrationBuilder.RenameColumn(
                name: "IngrediensId",
                table: "Ingredience",
                newName: "IngredienceId");
        }
    }
}
