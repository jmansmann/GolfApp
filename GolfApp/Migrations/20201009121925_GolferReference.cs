using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfApp.Migrations
{
    public partial class GolferReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Round_Golfer_GolferId",
                table: "Round");

            migrationBuilder.AlterColumn<int>(
                name: "GolferId",
                table: "Round",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Golfer_GolferId",
                table: "Round",
                column: "GolferId",
                principalTable: "Golfer",
                principalColumn: "GolferId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Round_Golfer_GolferId",
                table: "Round");

            migrationBuilder.AlterColumn<int>(
                name: "GolferId",
                table: "Round",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Golfer_GolferId",
                table: "Round",
                column: "GolferId",
                principalTable: "Golfer",
                principalColumn: "GolferId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
