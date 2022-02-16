using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll.DAL.Migrations
{
    public partial class AuditRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditRequests",
                columns: table => new
                {
                    AuditRequestID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedURL = table.Column<string>(maxLength: 1000, nullable: true),
                    RequestedController = table.Column<string>(maxLength: 200, nullable: true),
                    RequestedActionMethod = table.Column<string>(maxLength: 200, nullable: true),
                    RequestedDateTime = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRequests", x => x.AuditRequestID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditRequests");
        }
    }
}
