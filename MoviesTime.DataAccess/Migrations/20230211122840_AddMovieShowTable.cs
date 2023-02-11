using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.Contract.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieShowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieShows",
                columns: table => new
                {
                    ShowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    ShowStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShows", x => x.ShowID);
                    table.ForeignKey(
                        name: "FK_MovieShows_Languages_LanguageID1",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieShows_Movies_MovieID1",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieShows_TheaterScreens_ScreenID1",
                        column: x => x.ScreenID,
                        principalTable: "TheaterScreens",
                        principalColumn: "ScreenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_LanguageID1",
                table: "MovieShows",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_MovieID1",
                table: "MovieShows",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_ScreenID1",
                table: "MovieShows",
                column: "ScreenID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieShows");
        }
    }
}
