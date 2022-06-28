using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiSchool.Infrastructure.Migrations
{
    public partial class makeFieldsOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Rental_RentalId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Timetable_TimetableId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "TimetableId",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Rental_RentalId",
                table: "Payment",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Timetable_TimetableId",
                table: "Payment",
                column: "TimetableId",
                principalTable: "Timetable",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Rental_RentalId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Timetable_TimetableId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "TimetableId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Rental_RentalId",
                table: "Payment",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Timetable_TimetableId",
                table: "Payment",
                column: "TimetableId",
                principalTable: "Timetable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
