using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.Contract.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesTheaterReviewsANDScreens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheaterReview",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheaterID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    ReviewMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedFromReviewID = table.Column<int>(type: "int", nullable: true),
                    RegisteredUserID = table.Column<int>(type: "int", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterReview", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_TheaterReview_Theaters_TheaterID1",
                        column: x => x.TheaterID,
                        principalTable: "Theaters",
                        principalColumn: "TheaterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheaterReview_Users_RegisteredUserIDUserID",
                        column: x => x.RegisteredUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

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
                        name: "FK_TheaterScreens_Theaters_TheaterID1",
                        column: x => x.TheaterID,
                        principalTable: "Theaters",
                        principalColumn: "TheaterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheaterReview_RegisteredUserIDUserID",
                table: "TheaterReview",
                column: "RegisteredUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterReview_TheaterID1",
                table: "TheaterReview",
                column: "TheaterID");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterScreens_TheaterID1",
                table: "TheaterScreens",
                column: "TheaterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheaterReview");

            migrationBuilder.DropTable(
                name: "TheaterScreens");
        }
    }
}
