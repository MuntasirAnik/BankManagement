using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67c97396-9b0b-432a-8ce4-e89973c6ac66", null, "Employee", "EMPLOYEE" },
                    { "75f67c2a-d2eb-4832-89e7-0a092eb2c065", null, "Customer", "CUSTOMER" },
                    { "e7808622-bb53-4bd3-afdc-184cf309845c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67c97396-9b0b-432a-8ce4-e89973c6ac66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75f67c2a-d2eb-4832-89e7-0a092eb2c065");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7808622-bb53-4bd3-afdc-184cf309845c");
        }
    }
}
