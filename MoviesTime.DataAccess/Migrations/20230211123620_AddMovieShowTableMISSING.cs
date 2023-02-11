using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesTime.Contract.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieShowTableMISSING : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowID = table.Column<int>(type: "int", nullable: false),
                    TicketsCount = table.Column<byte>(type: "tinyint", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    MovieStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredUserID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_MovieShows_ShowID1",
                        column: x => x.ShowID,
                        principalTable: "MovieShows",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_RegisteredUserIDUserID",
                        column: x => x.RegisteredUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RegisteredUserIDUserID",
                table: "Tickets",
                column: "RegisteredUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowID1",
                table: "Tickets",
                column: "ShowID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
