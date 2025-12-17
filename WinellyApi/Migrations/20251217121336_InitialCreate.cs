using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinellyApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Taste = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wineries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    EstablishedYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wineries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    AlcoholContent = table.Column<int>(type: "INTEGER", nullable: false),
                    WineryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wines_Wineries_WineryId",
                        column: x => x.WineryId,
                        principalTable: "Wineries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WineryId = table.Column<int>(type: "INTEGER", nullable: false),
                    WineId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Wineries_WineryId",
                        column: x => x.WineryId,
                        principalTable: "Wineries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wine_GrapeConnections",
                columns: table => new
                {
                    WineId = table.Column<int>(type: "INTEGER", nullable: false),
                    GrapeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wine_GrapeConnections", x => new { x.WineId, x.GrapeId });
                    table.ForeignKey(
                        name: "FK_Wine_GrapeConnections_Grapes_GrapeId",
                        column: x => x.GrapeId,
                        principalTable: "Grapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wine_GrapeConnections_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_WineId",
                table: "Ratings",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_WineryId",
                table: "Ratings",
                column: "WineryId");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_GrapeConnections_GrapeId",
                table: "Wine_GrapeConnections",
                column: "GrapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_WineryId",
                table: "Wines",
                column: "WineryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Wine_GrapeConnections");

            migrationBuilder.DropTable(
                name: "Grapes");

            migrationBuilder.DropTable(
                name: "Wines");

            migrationBuilder.DropTable(
                name: "Wineries");
        }
    }
}
