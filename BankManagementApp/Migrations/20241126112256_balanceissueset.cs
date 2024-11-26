using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class balanceissueset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58c6b889-635c-48a3-bab7-05f8735683d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7509aff7-9cf0-4737-9a61-31fb89f9bae9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7f012d7-dcca-45f1-af48-b8e1d8357053");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d8a31a7-1739-4d03-a658-c25e391b563a", null, "Customer", "CUSTOMER" },
                    { "952673fb-69a9-414b-90ab-40747faab6a0", null, "Admin", "ADMIN" },
                    { "961fd82e-2157-41ca-89ef-95849ad67c51", null, "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d8a31a7-1739-4d03-a658-c25e391b563a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "952673fb-69a9-414b-90ab-40747faab6a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "961fd82e-2157-41ca-89ef-95849ad67c51");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58c6b889-635c-48a3-bab7-05f8735683d8", null, "Customer", "CUSTOMER" },
                    { "7509aff7-9cf0-4737-9a61-31fb89f9bae9", null, "Employee", "EMPLOYEE" },
                    { "f7f012d7-dcca-45f1-af48-b8e1d8357053", null, "Admin", "ADMIN" }
                });
        }
    }
}
