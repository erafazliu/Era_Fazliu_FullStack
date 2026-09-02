using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PECB.SupportDesk.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedAgentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ResolvedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ClosedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Agents_AssignedAgentId",
                        column: x => x.AssignedAgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Active", "Department", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, true, "Technical", "arta@pecb.test", "Arta Krasniqi" },
                    { 2, true, "Billing", "blerim@pecb.test", "Blerim Hoxha" },
                    { 3, true, "General", "dua@pecb.test", "Dua Gashi" },
                    { 4, true, "Technical", "luan@pecb.test", "Luan Berisha" },
                    { 5, false, "General", "mira@pecb.test", "Mira Shala" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AssignedAgentId", "ClosedDate", "CreatedDate", "CustomerEmail", "CustomerName", "Description", "DueDate", "LastModifiedDate", "Priority", "Reference", "ResolvedDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, null, null, new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer1@example.com", "Customer 1", "Seeded ticket 1 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-2026-0001", null, "New", "Sample support request 1" },
                    { 5, null, null, new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer5@example.com", "Customer 5", "Seeded ticket 5 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-2026-0005", null, "New", "Sample support request 5" },
                    { 9, null, null, new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer9@example.com", "Customer 9", "Seeded ticket 9 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-2026-0009", null, "New", "Sample support request 9" },
                    { 13, null, null, new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer13@example.com", "Customer 13", "Seeded ticket 13 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-2026-0013", null, "New", "Sample support request 13" },
                    { 17, null, null, new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer17@example.com", "Customer 17", "Seeded ticket 17 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Critical", "TCK-2026-0017", null, "New", "Sample support request 17" },
                    { 2, 3, null, new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer2@example.com", "Customer 2", "Seeded ticket 2 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-2026-0002", null, "InProgress", "Sample support request 2" },
                    { 3, 4, null, new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer3@example.com", "Customer 3", "Seeded ticket 3 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-2026-0003", new DateTimeOffset(new DateTime(2026, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 3" },
                    { 4, 1, new DateTimeOffset(new DateTime(2026, 8, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer4@example.com", "Customer 4", "Seeded ticket 4 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-2026-0004", new DateTimeOffset(new DateTime(2026, 8, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 4" },
                    { 6, 3, null, new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer6@example.com", "Customer 6", "Seeded ticket 6 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-2026-0006", null, "InProgress", "Sample support request 6" },
                    { 7, 4, null, new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer7@example.com", "Customer 7", "Seeded ticket 7 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-2026-0007", new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 7" },
                    { 8, 1, new DateTimeOffset(new DateTime(2026, 8, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer8@example.com", "Customer 8", "Seeded ticket 8 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-2026-0008", new DateTimeOffset(new DateTime(2026, 8, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 8" },
                    { 10, 3, null, new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer10@example.com", "Customer 10", "Seeded ticket 10 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-2026-0010", null, "InProgress", "Sample support request 10" },
                    { 11, 4, null, new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer11@example.com", "Customer 11", "Seeded ticket 11 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-2026-0011", new DateTimeOffset(new DateTime(2026, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 11" },
                    { 12, 1, new DateTimeOffset(new DateTime(2026, 8, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer12@example.com", "Customer 12", "Seeded ticket 12 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-2026-0012", new DateTimeOffset(new DateTime(2026, 8, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 12" },
                    { 14, 3, null, new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer14@example.com", "Customer 14", "Seeded ticket 14 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-2026-0014", null, "InProgress", "Sample support request 14" },
                    { 15, 4, null, new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer15@example.com", "Customer 15", "Seeded ticket 15 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-2026-0015", new DateTimeOffset(new DateTime(2026, 8, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 15" },
                    { 16, 1, new DateTimeOffset(new DateTime(2026, 8, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer16@example.com", "Customer 16", "Seeded ticket 16 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-2026-0016", new DateTimeOffset(new DateTime(2026, 8, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 16" },
                    { 18, 3, null, new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer18@example.com", "Customer 18", "Seeded ticket 18 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "High", "TCK-2026-0018", null, "InProgress", "Sample support request 18" },
                    { 19, 4, null, new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer19@example.com", "Customer 19", "Seeded ticket 19 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Normal", "TCK-2026-0019", new DateTimeOffset(new DateTime(2026, 8, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Resolved", "Sample support request 19" },
                    { 20, 1, new DateTimeOffset(new DateTime(2026, 8, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "customer20@example.com", "Customer 20", "Seeded ticket 20 for evaluating the workflow.", new DateTimeOffset(new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2026, 8, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Low", "TCK-2026-0020", new DateTimeOffset(new DateTime(2026, 8, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Closed", "Sample support request 20" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Email",
                table: "Agents",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TicketId",
                table: "Comments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedAgentId",
                table: "Tickets",
                column: "AssignedAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Reference",
                table: "Tickets",
                column: "Reference",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
