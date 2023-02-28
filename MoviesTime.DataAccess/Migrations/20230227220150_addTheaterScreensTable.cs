using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTheaterScreensTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheaterScreens",
                columns: table => new
                {
                    ScreenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TheaterID = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterScreens", x => x.ScreenID);
                    table.ForeignKey(
                        name: "FK_TheaterScreens_Theaters_TheaterID",
                        column: x => x.TheaterID,
                        principalTable: "Theaters",
                        principalColumn: "TheaterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheaterScreens_TheaterID",
                table: "TheaterScreens",
                column: "TheaterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheaterScreens");
        }
    }
}
