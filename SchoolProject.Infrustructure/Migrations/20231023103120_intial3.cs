using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class intial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InstructorManagerId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InstructorManagerId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorManagerId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorManagerId",
                table: "Departments",
                column: "InstructorManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InstructorManagerId",
                table: "Departments",
                column: "InstructorManagerId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InstructorManagerId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InstructorManagerId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorManagerId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorManagerId",
                table: "Departments",
                column: "InstructorManagerId",
                unique: true,
                filter: "[InstructorManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InstructorManagerId",
                table: "Departments",
                column: "InstructorManagerId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }
    }
}
