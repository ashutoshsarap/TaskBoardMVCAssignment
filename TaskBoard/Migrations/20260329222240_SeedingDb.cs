using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskBoard.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CurrentStatus", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 0, "Description for Task 1", "Task 1" },
                    { 2, 0, "Description for Task 2", "Task 2" },
                    { 3, 0, "Description for Task 3", "Task 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
