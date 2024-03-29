﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlannerMVC.Infrastructure.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BudgetUsers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Not assigned", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BudgetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
