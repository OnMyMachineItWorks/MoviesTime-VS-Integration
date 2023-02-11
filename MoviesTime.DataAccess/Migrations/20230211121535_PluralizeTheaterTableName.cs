using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.Contract.Migrations
{
    /// <inheritdoc />
    public partial class PluralizeTheaterTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theater_TheaterID",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Theater");

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    TheaterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheaterName = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false),
                    TheaterContact = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.TheaterID);
                    table.ForeignKey(
                        name: "FK_Theaters_Users_ManagerIDUserID",
                        column: x => x.ManagerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theaters_ManagerIDUserID",
                table: "Theaters",
                column: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Theaters_TheaterID1",
                table: "Movies",
                column: "TheaterID",
                principalTable: "Theaters",
                principalColumn: "TheaterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theaters_TheaterID1",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Theaters");

            migrationBuilder.RenameColumn(
                name: "TheaterID1",
                table: "Movies",
                newName: "TheaterID");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_TheaterID1",
                table: "Movies",
                newName: "IX_Movies_TheaterID");

            migrationBuilder.CreateTable(
                name: "Theater",
                columns: table => new
                {
                    TheaterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerIDUserID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TheaterContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.TheaterID);
                    table.ForeignKey(
                        name: "FK_Theater_Users_ManagerIDUserID",
                        column: x => x.ManagerIDUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theater_ManagerIDUserID",
                table: "Theater",
                column: "ManagerIDUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Theater_TheaterID",
                table: "Movies",
                column: "TheaterID",
                principalTable: "Theater",
                principalColumn: "TheaterID");
        }
    }
}
