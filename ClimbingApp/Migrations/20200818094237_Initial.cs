using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoulderAverage",
                columns: table => new
                {
                    BoulderAverageID = table.Column<int>(nullable: false),
                    PullUps = table.Column<int>(nullable: false),
                    PushUps = table.Column<int>(nullable: false),
                    HangEdge = table.Column<int>(nullable: false),
                    HangWeight = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoulderAverage", x => x.BoulderAverageID);
                });

            migrationBuilder.CreateTable(
                name: "Boulders",
                columns: table => new
                {
                    BoulderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    BoulderingClimbingGrade = table.Column<int>(nullable: false),
                    ConsensusGrade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boulders", x => x.BoulderID);
                });

            migrationBuilder.CreateTable(
                name: "SportAverage",
                columns: table => new
                {
                    SportAverageID = table.Column<int>(nullable: false),
                    PullUps = table.Column<int>(nullable: false),
                    PushUps = table.Column<int>(nullable: false),
                    HangEdge = table.Column<int>(nullable: false),
                    HangWeight = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportAverage", x => x.SportAverageID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    SportClimbingGrade = table.Column<int>(nullable: false),
                    ConsensusGrade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    ApeIndex = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    BoulderID = table.Column<int>(nullable: true),
                    SportID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Boulders_BoulderID",
                        column: x => x.BoulderID,
                        principalTable: "Boulders",
                        principalColumn: "BoulderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllStats",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    UserID1 = table.Column<string>(nullable: true),
                    PullUps = table.Column<int>(nullable: false),
                    PushUps = table.Column<int>(nullable: false),
                    HangEdge = table.Column<int>(nullable: false),
                    HangWeight = table.Column<int>(nullable: false),
                    HighestSportGrade = table.Column<int>(nullable: false),
                    HighestBoulderingGrade = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllStats", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_AllStats_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    StatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PullUpID = table.Column<int>(nullable: true),
                    PushUpID = table.Column<int>(nullable: true),
                    HangEdgeID = table.Column<int>(nullable: true),
                    HangWeightID = table.Column<int>(nullable: true),
                    HighestSportGrade = table.Column<int>(nullable: false),
                    HighestBoulderingGrade = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.StatID);
                    table.ForeignKey(
                        name: "FK_Stats_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HangEdges",
                columns: table => new
                {
                    HangEdgeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NHangEdge = table.Column<int>(nullable: false),
                    StatID = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangEdges", x => x.HangEdgeID);
                    table.ForeignKey(
                        name: "FK_HangEdges_Stats_StatID",
                        column: x => x.StatID,
                        principalTable: "Stats",
                        principalColumn: "StatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HangWeights",
                columns: table => new
                {
                    HangWeightID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NHangWeight = table.Column<int>(nullable: false),
                    StatID = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangWeights", x => x.HangWeightID);
                    table.ForeignKey(
                        name: "FK_HangWeights_Stats_StatID",
                        column: x => x.StatID,
                        principalTable: "Stats",
                        principalColumn: "StatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PullUps",
                columns: table => new
                {
                    PullUpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NPullUps = table.Column<int>(nullable: false),
                    StatID = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PullUps", x => x.PullUpID);
                    table.ForeignKey(
                        name: "FK_PullUps_Stats_StatID",
                        column: x => x.StatID,
                        principalTable: "Stats",
                        principalColumn: "StatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PushUps",
                columns: table => new
                {
                    PushUpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NPushUps = table.Column<int>(nullable: false),
                    StatID = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushUps", x => x.PushUpID);
                    table.ForeignKey(
                        name: "FK_PushUps_Stats_StatID",
                        column: x => x.StatID,
                        principalTable: "Stats",
                        principalColumn: "StatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllStats_UserID1",
                table: "AllStats",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_HangEdges_StatID",
                table: "HangEdges",
                column: "StatID");

            migrationBuilder.CreateIndex(
                name: "IX_HangWeights_StatID",
                table: "HangWeights",
                column: "StatID");

            migrationBuilder.CreateIndex(
                name: "IX_PullUps_StatID",
                table: "PullUps",
                column: "StatID");

            migrationBuilder.CreateIndex(
                name: "IX_PushUps_StatID",
                table: "PushUps",
                column: "StatID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Stats_UserID",
                table: "Stats",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BoulderID",
                table: "Users",
                column: "BoulderID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SportID",
                table: "Users",
                column: "SportID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Users_UserID",
                table: "Stats");

            migrationBuilder.DropForeignKey(
                name: "FK_HangEdges_Stats_StatID",
                table: "HangEdges");

            migrationBuilder.DropForeignKey(
                name: "FK_HangWeights_Stats_StatID",
                table: "HangWeights");

            migrationBuilder.DropForeignKey(
                name: "FK_PullUps_Stats_StatID",
                table: "PullUps");

            migrationBuilder.DropTable(
                name: "AllStats");

            migrationBuilder.DropTable(
                name: "BoulderAverage");

            migrationBuilder.DropTable(
                name: "PushUps");

            migrationBuilder.DropTable(
                name: "SportAverage");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Boulders");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "HangEdges");

            migrationBuilder.DropTable(
                name: "HangWeights");

            migrationBuilder.DropTable(
                name: "PullUps");
        }
    }
}
