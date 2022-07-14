using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlannerMVC.Infrastructure.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactDetailTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mail" });

            migrationBuilder.InsertData(
                table: "ContactDetailTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Phone Number" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactDetailTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactDetailTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
