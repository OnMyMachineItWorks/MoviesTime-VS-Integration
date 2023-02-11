using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.Contract.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTheaterReviewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheaterReview");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheaterReview",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredUserIDUserID = table.Column<int>(type: "int", nullable: false),
                    TheaterID = table.Column<int>(type: "int", nullable: false),
                    EditedFromReviewID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    ReviewMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterReview", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_TheaterReview_Theater_TheaterID",
                        column: x => x.TheaterID,
                        principalTable: "Theater",
                        principalColumn: "TheaterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheaterReview_Users_RegisteredUserIDUserID",
                        column: x => x.RegisteredUserIDUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheaterReview_RegisteredUserIDUserID",
                table: "TheaterReview",
                column: "RegisteredUserIDUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterReview_TheaterID",
                table: "TheaterReview",
                column: "TheaterID");
        }
    }
}
