using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedDescriptionColumnToTheaterScreensTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScreenDescription",
                table: "TheaterScreens",
                type: "nvarchar(500)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenDescription",
                table: "TheaterScreens");
        }
    }
}
