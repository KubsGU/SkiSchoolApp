using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiSchool.Infrastructure.Migrations
{
    public partial class redesignDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Equipment_EquipmentId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Timetable_TimetableId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Equipment_EquipmentId",
                table: "Rental");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_Rental_EquipmentId",
                table: "Rental");

            migrationBuilder.DropIndex(
                name: "IX_Payment_EquipmentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "TimetableId",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_RentalId",
                table: "Payment",
                column: "RentalId");

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

            migrationBuilder.DropIndex(
                name: "IX_Payment_RentalId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TimetableId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Reminder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_EquipmentId",
                table: "Rental",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_EquipmentId",
                table: "Payment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Equipment_EquipmentId",
                table: "Payment",
                column: "EquipmentId",
                principalTable: "Equipment",
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
                name: "FK_Rental_Equipment_EquipmentId",
                table: "Rental",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
