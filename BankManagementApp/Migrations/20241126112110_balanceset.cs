using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class balanceset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22248143-d308-4d80-9f28-b2f2b86d6157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "486a32ec-f32d-49f2-b702-e31f0342133b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a0e7430-203c-43c1-bbbc-87683862eb09");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "22248143-d308-4d80-9f28-b2f2b86d6157", null, "Employee", "EMPLOYEE" },
                    { "486a32ec-f32d-49f2-b702-e31f0342133b", null, "Customer", "CUSTOMER" },
                    { "5a0e7430-203c-43c1-bbbc-87683862eb09", null, "Admin", "ADMIN" }
                });
        }
    }
}
