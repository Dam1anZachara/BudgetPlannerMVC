using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlannerMVC.Infrastructure.Migrations
{
    public partial class InitialCreate8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AspNetUserId",
                table: "BudgetUsers",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "e1717d79-6251-4fb1-83b3-1ef5cc85c83e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "PreUser",
                column: "ConcurrencyStamp",
                value: "a1202ac2-0342-43fd-a4a0-cc51c6531265");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "451c4c04-ba2a-47e1-bffe-7f5976cc6a5c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BudgetUsers",
                newName: "AspNetUserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "50ed201b-7269-462c-9646-b39bf761fab2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "PreUser",
                column: "ConcurrencyStamp",
                value: "3409b56b-ff11-4f1c-8b45-723b8ef5dc9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "3829c234-a5a0-4be8-9921-d62cb9f6998c");
        }
    }
}
