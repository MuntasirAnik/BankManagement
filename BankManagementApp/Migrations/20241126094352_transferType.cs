using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class transferType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Accounts",
                newName: "Balance");

            migrationBuilder.CreateTable(
                name: "FundTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferTypeId = table.Column<int>(type: "int", nullable: false),
                    TransferTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransferTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundTransfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTypes", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundTransfers");

            migrationBuilder.DropTable(
                name: "TransferTypes");

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

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Accounts",
                newName: "balance");

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
    }
}
