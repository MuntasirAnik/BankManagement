using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bff84398-f99f-453f-a7e8-d5b4dd0ac6cf", "AQAAAAIAAYagAAAAEFuolBShzzwH0Umc/Ud/wor+jh/9v1zMfjjDsC+3VgCKC1wYrryx5QljsWpzINIAAQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc173e7b-fa9f-4de4-a16b-b4f8fcd2058e", "AQAAAAIAAYagAAAAEL092no3yySk+3cRigpc1eOZCMyeBXrsL8GZQw3Yruk4p9f2bCuHJMb2ABko+aszXQ==" });
        }
    }
}
