using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessLogApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class LogIcollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Exercise_ExerciseId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Exercise_ExerciseId",
                table: "Log",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Exercise_ExerciseId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Log",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Exercise_ExerciseId",
                table: "Log",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id");
        }
    }
}
