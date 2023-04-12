using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Student.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Name", "standard" },
                values: new object[,]
                {
                    { 1, "Arjun", 4 },
                    { 2, "Bashir", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
