using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlannerMVC.Infrastructure.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", "50ed201b-7269-462c-9646-b39bf761fab2", "Admin", "ADMIN" },
                    { "User", "3829c234-a5a0-4be8-9921-d62cb9f6998c", "User", "USER" },
                    { "PreUser", "3409b56b-ff11-4f1c-8b45-723b8ef5dc9a", "PreUser", "PREUSER" }
                });

            migrationBuilder.UpdateData(
                table: "BudgetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileCreated",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "PreUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User");

            migrationBuilder.UpdateData(
                table: "BudgetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileCreated",
                value: false);
        }
    }
}
