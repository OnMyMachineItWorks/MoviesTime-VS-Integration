using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.Contract.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieReview",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    MovieRating = table.Column<byte>(type: "tinyint", nullable: false),
                    ReviewMessage = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EditedFromReviewID = table.Column<int>(type: "int", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue:false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReview", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_MovieReview_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieReview_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieReview_MovieID",
                table: "MovieReview",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieReview_UserID",
                table: "MovieReview",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieReview");
        }
    }
}
