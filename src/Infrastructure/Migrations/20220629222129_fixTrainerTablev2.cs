using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiSchool.Infrastructure.Migrations
{
    public partial class fixTrainerTablev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Trainer_TrainerId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TrainerId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Schedule");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_ScheduleId",
                table: "Trainer",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Schedule_ScheduleId",
                table: "Trainer",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Schedule_ScheduleId",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_ScheduleId",
                table: "Trainer");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainerId",
                table: "Schedule",
                column: "TrainerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Trainer_TrainerId",
                table: "Schedule",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
