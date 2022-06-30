using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiSchool.Infrastructure.Migrations
{
    public partial class fixTrainerTablev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trainer_ScheduleId",
                table: "Trainer");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_ScheduleId",
                table: "Trainer",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trainer_ScheduleId",
                table: "Trainer");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_ScheduleId",
                table: "Trainer",
                column: "ScheduleId",
                unique: true);
        }
    }
}
