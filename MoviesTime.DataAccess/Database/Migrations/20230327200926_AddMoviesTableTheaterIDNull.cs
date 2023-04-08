using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMoviesTableTheaterIDNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theaters_TheaterID",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterID",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Theaters_TheaterID",
                table: "Movies",
                column: "TheaterID",
                principalTable: "Theaters",
                principalColumn: "TheaterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theaters_TheaterID",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Theaters_TheaterID",
                table: "Movies",
                column: "TheaterID",
                principalTable: "Theaters",
                principalColumn: "TheaterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
