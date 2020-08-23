using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingApp.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_HangEdges_HangEdgeID",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_HangWeights_HangWeightID",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_PullUps_PullUpID",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_PullUps_PushUpID",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_HangEdgeID",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_HangWeightID",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_PullUpID",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_PushUpID",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "HangEdgeID",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "HangWeightID",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "PullUpID",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "PushUpID",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "NPushUps",
                table: "PushUps");

            migrationBuilder.DropColumn(
                name: "NPullUps",
                table: "PullUps");

            migrationBuilder.AddColumn<int>(
                name: "HangEdge",
                table: "Stats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HangWeight",
                table: "Stats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PullUp",
                table: "Stats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PushUp",
                table: "Stats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NPushUp",
                table: "PushUps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NPullUp",
                table: "PullUps",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HangEdge",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "HangWeight",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "PullUp",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "PushUp",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "NPushUp",
                table: "PushUps");

            migrationBuilder.DropColumn(
                name: "NPullUp",
                table: "PullUps");

            migrationBuilder.AddColumn<int>(
                name: "HangEdgeID",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HangWeightID",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PullUpID",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PushUpID",
                table: "Stats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NPushUps",
                table: "PushUps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NPullUps",
                table: "PullUps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_HangEdgeID",
                table: "Stats",
                column: "HangEdgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_HangWeightID",
                table: "Stats",
                column: "HangWeightID");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PullUpID",
                table: "Stats",
                column: "PullUpID");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PushUpID",
                table: "Stats",
                column: "PushUpID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_HangEdges_HangEdgeID",
                table: "Stats",
                column: "HangEdgeID",
                principalTable: "HangEdges",
                principalColumn: "HangEdgeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_HangWeights_HangWeightID",
                table: "Stats",
                column: "HangWeightID",
                principalTable: "HangWeights",
                principalColumn: "HangWeightID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_PullUps_PullUpID",
                table: "Stats",
                column: "PullUpID",
                principalTable: "PullUps",
                principalColumn: "PullUpID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_PullUps_PushUpID",
                table: "Stats",
                column: "PushUpID",
                principalTable: "PullUps",
                principalColumn: "PullUpID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
