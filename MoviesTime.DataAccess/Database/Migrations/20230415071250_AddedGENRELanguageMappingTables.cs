using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedGENRELanguageMappingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieGenreMapping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql:"1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenreMapping", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieGenreMapping_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenreMapping_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguageMapping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguageMapping", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieLanguageMapping_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguageMapping_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenreMapping_GenreID",
                table: "MovieGenreMapping",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenreMapping_MovieID",
                table: "MovieGenreMapping",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguageMapping_LanguageID",
                table: "MovieLanguageMapping",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguageMapping_MovieID",
                table: "MovieLanguageMapping",
                column: "MovieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenreMapping");

            migrationBuilder.DropTable(
                name: "MovieLanguageMapping");
        }
    }
}
