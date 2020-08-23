using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingApp.Migrations
{
    public partial class Logbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Boulders_BoulderID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sports_SportID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BoulderID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SportID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BoulderID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SportID",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Stats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Sports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "PushUps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "PullUps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "HangWeights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "HangEdges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Boulders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "BoulderAverage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "AllStats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogID = table.Column<string>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    StatID = table.Column<int>(nullable: true),
                    BoulderID = table.Column<int>(nullable: false),
                    SportID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_Logs_Boulders_BoulderID",
                        column: x => x.BoulderID,
                        principalTable: "Boulders",
                        principalColumn: "BoulderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Stats_StatID",
                        column: x => x.StatID,
                        principalTable: "Stats",
                        principalColumn: "StatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_BoulderID",
                table: "Logs",
                column: "BoulderID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SportID",
                table: "Logs",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_StatID",
                table: "Logs",
                column: "StatID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserID",
                table: "Logs",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "PushUps");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "PullUps");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "HangWeights");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "HangEdges");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Boulders");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "BoulderAverage");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "AllStats");

            migrationBuilder.AddColumn<int>(
                name: "BoulderID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BoulderID",
                table: "Users",
                column: "BoulderID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SportID",
                table: "Users",
                column: "SportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Boulders_BoulderID",
                table: "Users",
                column: "BoulderID",
                principalTable: "Boulders",
                principalColumn: "BoulderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sports_SportID",
                table: "Users",
                column: "SportID",
                principalTable: "Sports",
                principalColumn: "SportID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
