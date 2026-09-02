using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PECB.SupportDesk.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEliraAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Active", "Department", "Email", "FullName" },
                values: new object[] { -1, true, "Billing", "elira@pecb.test", "Elira Dervishi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
