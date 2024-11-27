using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class emailaddincustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16bae9ae-3c1d-40e8-bbcd-7d0f4efb196b", null, "Employee", "EMPLOYEE" },
                    { "4bd671c7-3b98-404c-85a3-5a838b9cd316", null, "Admin", "ADMIN" },
                    { "ffefb5a0-1e8e-4abb-85c3-ecc32d5efb27", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16bae9ae-3c1d-40e8-bbcd-7d0f4efb196b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bd671c7-3b98-404c-85a3-5a838b9cd316");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffefb5a0-1e8e-4abb-85c3-ecc32d5efb27");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

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
    }
}
