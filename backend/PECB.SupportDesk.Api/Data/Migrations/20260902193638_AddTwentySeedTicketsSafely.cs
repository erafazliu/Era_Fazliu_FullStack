using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PECB.SupportDesk.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTwentySeedTicketsSafely : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AssignedAgentId", "ClosedDate", "CreatedDate", "CustomerEmail", "CustomerName", "Description", "DueDate", "LastModifiedDate", "Priority", "Reference", "ResolvedDate", "Status", "Title" },
                values: new object[,]
                {
                    { -20, null, null, new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer21@example.com", "Customer 21", "Seeded ticket 21 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-SEED-0021", null, "New", "Sample support request 21" },
                    { -19, 3, null, new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer22@example.com", "Customer 22", "Seeded ticket 22 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-SEED-0022", null, "InProgress", "Sample support request 22" },
                    { -18, 4, null, new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer23@example.com", "Customer 23", "Seeded ticket 23 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-SEED-0023", new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 23" },
                    { -17, 1, new DateTimeOffset(new DateTime(2026, 8, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer24@example.com", "Customer 24", "Seeded ticket 24 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-SEED-0024", new DateTimeOffset(new DateTime(2026, 8, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 24" },
                    { -16, null, null, new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer25@example.com", "Customer 25", "Seeded ticket 25 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-SEED-0025", null, "New", "Sample support request 25" },
                    { -15, 3, null, new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer26@example.com", "Customer 26", "Seeded ticket 26 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-SEED-0026", null, "InProgress", "Sample support request 26" },
                    { -14, 4, null, new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer27@example.com", "Customer 27", "Seeded ticket 27 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-SEED-0027", new DateTimeOffset(new DateTime(2026, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 27" },
                    { -13, 1, new DateTimeOffset(new DateTime(2026, 8, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer28@example.com", "Customer 28", "Seeded ticket 28 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-SEED-0028", new DateTimeOffset(new DateTime(2026, 8, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 28" },
                    { -12, null, null, new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer29@example.com", "Customer 29", "Seeded ticket 29 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-SEED-0029", null, "New", "Sample support request 29" },
                    { -11, 3, null, new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer30@example.com", "Customer 30", "Seeded ticket 30 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-SEED-0030", null, "InProgress", "Sample support request 30" },
                    { -10, 4, null, new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer31@example.com", "Customer 31", "Seeded ticket 31 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-SEED-0031", new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 31" },
                    { -9, 1, new DateTimeOffset(new DateTime(2026, 8, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer32@example.com", "Customer 32", "Seeded ticket 32 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-SEED-0032", new DateTimeOffset(new DateTime(2026, 8, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 32" },
                    { -8, null, null, new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer33@example.com", "Customer 33", "Seeded ticket 33 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-SEED-0033", null, "New", "Sample support request 33" },
                    { -7, 3, null, new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer34@example.com", "Customer 34", "Seeded ticket 34 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-SEED-0034", null, "InProgress", "Sample support request 34" },
                    { -6, 4, null, new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer35@example.com", "Customer 35", "Seeded ticket 35 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-SEED-0035", new DateTimeOffset(new DateTime(2026, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 35" },
                    { -5, 1, new DateTimeOffset(new DateTime(2026, 8, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer36@example.com", "Customer 36", "Seeded ticket 36 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-SEED-0036", new DateTimeOffset(new DateTime(2026, 8, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 36" },
                    { -4, null, null, new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer37@example.com", "Customer 37", "Seeded ticket 37 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-SEED-0037", null, "New", "Sample support request 37" },
                    { -3, 3, null, new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer38@example.com", "Customer 38", "Seeded ticket 38 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-SEED-0038", null, "InProgress", "Sample support request 38" },
                    { -2, 4, null, new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer39@example.com", "Customer 39", "Seeded ticket 39 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-SEED-0039", new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 39" },
                    { -1, 1, new DateTimeOffset(new DateTime(2026, 8, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer40@example.com", "Customer 40", "Seeded ticket 40 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-SEED-0040", new DateTimeOffset(new DateTime(2026, 8, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 40" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
