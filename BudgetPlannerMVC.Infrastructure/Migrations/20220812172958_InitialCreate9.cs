using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlannerMVC.Infrastructure.Migrations
{
    public partial class InitialCreate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "af77c64b-202b-4025-ad68-97d125b5bb3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "PreUser",
                column: "ConcurrencyStamp",
                value: "22d4b1f4-d8d4-49cd-9acd-361fb8344880");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "470ea227-a8d4-417f-a3b6-7684f7f9666e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Banned", "1cc3a98d-8a05-485b-afd9-bdff063c7c99", "Banned", "BANNED" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Banned");

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
    }
}
