using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class multicurrencyaddedinaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isMultiCurrency",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMultiCurrency",
                table: "Accounts");
        }
    }
}
