using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingApp.Migrations
{
    public partial class Question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Boulders_BoulderID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Sports_SportID",
                table: "Logs");

            migrationBuilder.AlterColumn<int>(
                name: "SportID",
                table: "Logs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BoulderID",
                table: "Logs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Boulders_BoulderID",
                table: "Logs",
                column: "BoulderID",
                principalTable: "Boulders",
                principalColumn: "BoulderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Sports_SportID",
                table: "Logs",
                column: "SportID",
                principalTable: "Sports",
                principalColumn: "SportID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Boulders_BoulderID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Sports_SportID",
                table: "Logs");

            migrationBuilder.AlterColumn<int>(
                name: "SportID",
                table: "Logs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BoulderID",
                table: "Logs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Boulders_BoulderID",
                table: "Logs",
                column: "BoulderID",
                principalTable: "Boulders",
                principalColumn: "BoulderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Sports_SportID",
                table: "Logs",
                column: "SportID",
                principalTable: "Sports",
                principalColumn: "SportID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
