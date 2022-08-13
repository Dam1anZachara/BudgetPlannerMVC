using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlannerMVC.Infrastructure.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "BudgetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "BudgetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "BudgetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "BudgetUsers");
        }
    }
}
