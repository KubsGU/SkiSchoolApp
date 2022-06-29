using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiSchool.Infrastructure.Migrations
{
    public partial class fixTrainerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedule_TrainerId",
                table: "Schedule");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainerId",
                table: "Schedule",
                column: "TrainerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedule_TrainerId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Trainer");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainerId",
                table: "Schedule",
                column: "TrainerId");
        }
    }
}
