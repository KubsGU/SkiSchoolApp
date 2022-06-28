using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiSchool.Infrastructure.Migrations
{
    public partial class improveRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Rental_RentalId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Timetable_TimetableId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rental_RentalId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Schedule");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rental_RentalId",
                table: "Reservation",
                column: "RentalId",
                principalTable: "Rental",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rental_RentalId",
                table: "Reservation");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Schedule",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Schedule",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rental_RentalId",
                table: "Reservation",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
