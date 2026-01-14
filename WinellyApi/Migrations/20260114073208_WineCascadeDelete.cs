using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinellyApi.Migrations
{
    /// <inheritdoc />
    public partial class WineCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wine_GrapeConnections_Grapes_GrapeId",
                table: "Wine_GrapeConnections");

            migrationBuilder.AlterColumn<double>(
                name: "AlcoholContent",
                table: "Wines",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_GrapeConnections_Grapes_GrapeId",
                table: "Wine_GrapeConnections",
                column: "GrapeId",
                principalTable: "Grapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wine_GrapeConnections_Grapes_GrapeId",
                table: "Wine_GrapeConnections");

            migrationBuilder.AlterColumn<int>(
                name: "AlcoholContent",
                table: "Wines",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_GrapeConnections_Grapes_GrapeId",
                table: "Wine_GrapeConnections",
                column: "GrapeId",
                principalTable: "Grapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
