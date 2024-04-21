using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTeamProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Draw",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Loss",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "goalsLosses",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "goalsScored",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Draw",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Loss",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "goalsLosses",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "goalsScored",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "City", "Draw", "Loss", "Name", "Wins", "goalsLosses", "goalsScored" },
                values: new object[,]
                {
                    { 1, "Kyiv", 0, 0, "Ukraine national football team", 0, 0, 0 },
                    { 2, "Portillo de Toledo", 0, 0, "Joma", 0, 0, 0 }
                });
        }
    }
}
