using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingApp.Migrations
{
    public partial class LongLat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Boulders");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Sports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Sports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Boulders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Boulders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Boulders");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Boulders");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Boulders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
