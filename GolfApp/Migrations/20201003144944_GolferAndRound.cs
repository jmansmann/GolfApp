using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfApp.Migrations
{
    public partial class GolferAndRound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Location",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Location",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "Hole",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Course",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFounded",
                table: "Course",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Golfer",
                columns: table => new
                {
                    GolferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golfer", x => x.GolferId);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    RoundId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePlayed = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    GolferId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Round_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Round_Golfer_GolferId",
                        column: x => x.GolferId,
                        principalTable: "Golfer",
                        principalColumn: "GolferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoleScore",
                columns: table => new
                {
                    HoleScoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoleId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    RoundId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoleScore", x => x.HoleScoreId);
                    table.ForeignKey(
                        name: "FK_HoleScore_Hole_HoleId",
                        column: x => x.HoleId,
                        principalTable: "Hole",
                        principalColumn: "HoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoleScore_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hole_RoundId",
                table: "Hole",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_HoleScore_HoleId",
                table: "HoleScore",
                column: "HoleId");

            migrationBuilder.CreateIndex(
                name: "IX_HoleScore_RoundId",
                table: "HoleScore",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_CourseId",
                table: "Round",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_GolferId",
                table: "Round",
                column: "GolferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hole_Round_RoundId",
                table: "Hole",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hole_Round_RoundId",
                table: "Hole");

            migrationBuilder.DropTable(
                name: "HoleScore");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Golfer");

            migrationBuilder.DropIndex(
                name: "IX_Hole_RoundId",
                table: "Hole");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "Hole");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFounded",
                table: "Course",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
