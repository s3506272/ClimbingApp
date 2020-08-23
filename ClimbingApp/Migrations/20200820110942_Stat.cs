using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingApp.Migrations
{
    public partial class Stat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Stats_StatID",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_StatID",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "StatID",
                table: "Logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatID",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_StatID",
                table: "Logs",
                column: "StatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Stats_StatID",
                table: "Logs",
                column: "StatID",
                principalTable: "Stats",
                principalColumn: "StatID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
